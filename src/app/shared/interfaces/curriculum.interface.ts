import { IRankType } from './rank-type.interface';

export interface ICurriculum {
  Id: number;
  Rank: number;
  RankTypeId: number;
  RankType: IRankType;
  Color: string;
}
