import { ICurriculum } from '../interfaces/curriculum.interface';

export class Curriculum implements ICurriculum {
  Id: number;
  Rank: number;
  RankTypeId: number;
  RankType: string;
  Color: string;
}
