import { IRankType } from '../interfaces/rank-type.interface';

export class RankType implements IRankType {
  Id: number;
  Name: string;
  SortOrderId: number;

  constructor(data?: IRankType) {
    if (data) {
      this.Id = data.Id;
      this.Name = data.Name;
      this.SortOrderId = data.SortOrderId;
    }
  }
}
