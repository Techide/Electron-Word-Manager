import { Component, OnInit } from "@angular/core";
import { DataService } from "../../../shared/services/data.service";
import { IRankType } from "../../../shared/interfaces/rank-type.interface";
import { MemoryStorageService } from "../../../shared/services/memory-storage.service";
import { NavigationService } from "src/app/shared/services/navigation.service";

@Component({
  selector: "ewm-rank-selection",
  templateUrl: "./rank-selection.component.html",
  styleUrls: ["./rank-selection.component.scss"]
})
export class RankSelectionComponent implements OnInit {
  ranks: IRankType[];
  private readonly navigateTo = "/curriculum";

  constructor(
    private dataService: DataService,
    private storageService: MemoryStorageService,
    private navigation: NavigationService
  ) {}

  async ngOnInit() {
    const result = await this.dataService.rankTypes.all();
    this.ranks = result;
    this.storageService.rankTypes = result;
  }

  onRankClicked(rankType: IRankType) {
    this.storageService.rank = rankType;
    this.navigation.navigate(
      [this.navigateTo, { outlets: { list: [rankType.Id] } }],
      { skipLocationChange: true }
    );
  }

  onCreateRankClicked() {
    this.navigation.navigate(["create"]);
  }

  onEditRankClicked() {
    this.navigation.navigate(["edit"]);
  }

  async onDeleteRankClicked(id: number) {
    await this.dataService.rankTypes.delete(id);
  }
}
