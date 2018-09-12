import { IWord } from './word.interface';

export interface IPart {
  Id: number;
  Name: string;
  CategoryId: number;
  ParentPartId?: number;
  Words: IWord[];
  SubParts: IPart[];
}
