import { Component, OnInit, AfterViewInit } from "@angular/core";
import { HttpErrorResponse } from "@angular/common/http";

import { DataService } from "../../../shared/services/data.service";
import { MemoryStorageService } from "../../../shared/services/memory-storage.service";
import { ICurriculum } from "../../../shared/interfaces/curriculum.interface";
import { NavigationService } from "src/app/shared/services/navigation.service";

@Component({
  selector: "ewm-curricula-list",
  templateUrl: "./curricula-list.component.html",
  styleUrls: ["./curricula-list.component.scss"]
})
export class CurriculaListComponent implements OnInit, AfterViewInit {
  curricula: ICurriculum[];

  selectedItem: number;

  constructor(
    private dataService: DataService,
    private storage: MemoryStorageService,
    private navigation: NavigationService) { }

  async ngOnInit() {
    const ranktype = this.storage.rank;
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

  async ngAfterViewInit() {
    this.selectedItem = this.storage.SelectedCurriculumId
  }

  anyItems(): boolean {
    return this.curricula ? this.curricula.length > 0 : false;
  }

  onCardClicked(id: number): void {
    this.storage.SelectedCurriculumId = id;
    this.selectedItem = id;
    this.navigation.navigate(["/curriculum", { outlets: { details: [id] } }], {
      skipLocationChange: true
    });
  }

  createCardClicked() {
    const model = <ICurriculum> {
      RankType: this.storage.rank.Name,
      RankTypeId: this.storage.rank.Id
    };
    this.storage.Curriculum = model;
    this.navigation.navigateByUrl("/curriculum/create");
  }

  editItem(item: ICurriculum) {
    this.storage.Curriculum = item;
    this.navigation.navigateByUrl("/curriculum/edit");
  }

  deleteItem(item: ICurriculum) {
    this.dataService.curricula.delete(item.Id)
      .then(id => {
        this.curricula = this.curricula.filter(x => { return x.Id !== id });
      }).catch(error => {
        const e = error as HttpErrorResponse;
        console.error(e.error);
      });
  }

}
