import { DataService } from "../../../shared/services/data.service";
import { ICurriculum } from "../../../shared/interfaces/curriculum.interface";
import { HttpErrorResponse } from "@angular/common/http";
import { MemoryStorageService } from "../../../shared/services/memory-storage.service";
import { Component, OnInit } from "@angular/core";
import { NavigationService } from "src/app/shared/services/navigation.service";

class IErrorMessage {
  PropertyName: string;
  ErrorMessage: string;
  AttemptedValue: any;
}

@Component({
  selector: "ewm-curriculum-form",
  templateUrl: "./curriculum-form.component.html",
  styleUrls: ["./curriculum-form.component.scss"]
})
export class CurriculumFormComponent implements OnInit {
  model: ICurriculum;

  // originalModel: ICurriculum;

  occupiedRanks: number[];

  errors: IErrorMessage[];

  constructor(
    private dataService: DataService,
    private storageService: MemoryStorageService,
    private navigation: NavigationService
  ) {
    this.model = <ICurriculum> {
      ...this.storageService.Curriculum,
      OriginalRank: this.storageService.Curriculum.Rank,
      OriginalColor: this.storageService.Curriculum.Color
    };
  }

  async ngOnInit(): Promise<void> {
    this.occupiedRanks = await this.getData();
  }

  async getData(): Promise<number[]> {
    const rank = this.storageService.rank;
    const dataArray: number[] = [];
    const data = await this.dataService.curricula.getByRankType(rank.Id);
    data.forEach(x => {
      dataArray.push(x.Rank);
    });
    return dataArray;
  }

  async submitForm() {
    let actionResult = null;

    this.model.OriginalRank
    try {
      if (this.model.Id > 0) {
        actionResult = await this.dataService.curricula.update(this.model);
      } else {
        actionResult = await this.dataService.curricula.create(this.model);
      }

      this.storageService.Curriculum = actionResult;
      this.navigation.navigateBack();
    } catch (error) {
      this.handleError(error);
    }
  }

  getTitle(): string {
    return this.model.Id > 0 ? "REDIGER" : "OPRET";
  }

  onBackButtonClicked() {
    this.navigation.navigateBack();
  }

  getDisableSubmit(formInvalid: boolean): boolean {
    if (formInvalid) {
      return formInvalid;
    }

    return this.equals(this.model);
  }

  sanitize(value: string) {
    return parseInt(value, 10);
  }

  private handleError(e: HttpErrorResponse) {
    this.errors = [];
    const errors = e.error.Errors as IErrorMessage[];
    errors.forEach(x => {
      this.errors.push(x);
    });
  }

  private equals(curriculum: ICurriculum): boolean {
    return curriculum.Rank === curriculum.OriginalRank && curriculum.Color === curriculum.OriginalColor;
  }
}
