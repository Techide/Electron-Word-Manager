import { Injectable } from '@angular/core';
import { CurriculumRepository } from '../repositories/curriculum.repository';
import { RankTypeRepository } from '../repositories/rank-type.repository';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  constructor(
    public curriculumns: CurriculumRepository,
    public ranks: RankTypeRepository
  ) {}
}
