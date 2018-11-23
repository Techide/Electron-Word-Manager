import { IRankType } from '../interfaces/rank-type.interface';

export class RankType implements IRankType {
  Id: number;
  Name: string;
  SortOrderId: number;

  constructor(data?: IRankType) {
    this.Id = data ? data.Id : null;
    this.Name = data ? data.Name : "";
    this.SortOrderId = data ? data.SortOrderId : null;
  }
}
