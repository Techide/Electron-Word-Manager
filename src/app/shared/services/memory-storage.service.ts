import { Injectable } from '@angular/core';
import { ICurriculum } from '../interfaces/curriculum.interface';
import { IPart } from '../interfaces/part.interface';
import { IRankType } from '../interfaces/rank-type.interface';

@Injectable({ providedIn: 'root' })
export class MemoryStorageService {
  public rankTypes: IRankType[];
  public rank: IRankType;

  public Curricula: ICurriculum[];
  public Curriculum: ICurriculum;

  public Details: IPart[];
  public Detail: IPart;
}
