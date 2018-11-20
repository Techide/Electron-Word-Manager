import { Component, OnInit } from "@angular/core";
import { HttpErrorResponse } from "@angular/common/http";

import { DataService } from "../../../shared/services/data.service";
import { MemoryStorageService } from "../../../shared/services/memory-storage.service";
import { ICurriculum } from "../../../shared/interfaces/curriculum.interface";
import { Curriculum } from "../../../shared/models/curriculum.model";
import { NavigationService } from "src/app/shared/services/navigation.service";

@Component({
  selector: "ewm-curricula-list",
  templateUrl: "./curricula-list.component.html",
  styleUrls: ["./curricula-list.component.scss"]
})
export class CurriculaListComponent implements OnInit {
  curricula: ICurriculum[];

  selectedItem: number;

  constructor(
    private dataService: DataService,
    private storageService: MemoryStorageService,
    private navigation: NavigationService
  ) {}

  async ngOnInit() {
    const ranktype = this.storageService.rank;
    this.curricula = await this.dataService.curricula
      .getByRankType(ranktype.Id)
      .then(x => {
        x.sort((a, b) => {
          if (ranktype.SortOrderId === 1) {
            return a.Rank - b.Rank;
          }
          return b.Rank - a.Rank;
        });
        return x;
      });
  }

  anyItems(): boolean {
    return this.curricula ? this.curricula.length > 0 : false;
  }

  onCardClicked(id: number): void {
    this.selectedItem = id;
    this.navigation.navigate(["/curriculum", { outlets: { details: [id] } }], {
      skipLocationChange: true
    });
  }

  createCardClicked() {
    const model = new Curriculum();
    model.RankType = this.storageService.rank.Name;
    model.RankTypeId = this.storageService.rank.Id;
    this.storageService.Curriculum = model;
    this.navigation.navigateByUrl("/curriculum/create", {
      skipLocationChange: true
    });
  }

  editItem(item: ICurriculum) {
    this.storageService.Curriculum = item;
    this.navigation.navigateByUrl("/curriculum/edit", {
      skipLocationChange: true
    });
  }

  async deleteItem(item: ICurriculum) {
    try {
      this.dataService.curricula.delete(item.Id);
      this.curricula.forEach((x, i) => {
        if (x.Id === item.Id) {
          this.curricula.splice(i, 1);
        }
      });
    } catch (error) {
      const e = error as HttpErrorResponse;
      console.error(e.error);
    }
  }
}
