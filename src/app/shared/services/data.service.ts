import { Injectable } from '@angular/core';
import { CurriculumRepository } from '../repositories/curriculum.repository';
import { GraduationRepository } from '../repositories/graduation.repository';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  constructor(
    public curriculumns: CurriculumRepository,
    public graduations: GraduationRepository
  ) {}
}
