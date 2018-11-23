import { Component, OnInit } from "@angular/core";
import { DataService } from "../../../shared/services/data.service";
import { IRankType } from "../../../shared/interfaces/rank-type.interface";
import { MemoryStorageService } from "../../../shared/services/memory-storage.service";
import { NavigationService } from "src/app/shared/services/navigation.service";
import { RankType } from "src/app/shared/models/rank-type.model";

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
    private navigator: NavigationService
  ) { }

  async ngOnInit() {
    const result = await this.dataService.rankTypes.all();
    this.ranks = result;
    this.storageService.rankTypes = result;
  }

  onRankClicked(rankType: IRankType) {
    this.storageService.rank = rankType;
    this.navigator.navigate(
      [this.navigateTo, { outlets: { list: [rankType.Id] } }]
    );
  }

  onCreateRankClicked() {
    this.storageService.rank = new RankType();
    this.navigator.navigate(["create"]);
  }

  onEditRankClicked(rankType: IRankType) {
    this.storageService.rank = rankType;
    this.navigator.navigate(["edit"]);
  }

  async onDeleteRankClicked(id: number) {
    await this.dataService.rankTypes.delete(id);
  }
}
