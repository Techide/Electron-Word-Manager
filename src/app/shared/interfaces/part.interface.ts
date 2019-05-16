import { IWord } from './word.interface';
import { ICategory } from './category.interface';

export interface IPart {
  Id: number;
  Name: string;
  CategoryId: number;
  Category: ICategory;
  ParentPartId?: number;
  Words: IWord[];
  SubParts: IPart[];
}
