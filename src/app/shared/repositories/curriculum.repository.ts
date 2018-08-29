import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseRepository } from './base-repository.abstract';

@Injectable({
  providedIn: 'root'
})
export class CurriculumRepository extends BaseRepository {
  constructor(private client: HttpClient) {
    super('http://localhost:5000/api/curriculums');
  }

  getByGraduationAndLanguages(
    graduationId: number,
    fromLanguageId: number,
    intoLanguageId: number
  ) {
    this.client
      .post(this.API_URL, {
        GraduationId: graduationId,
        FromLanguageId: fromLanguageId,
        IntoLanguageId: intoLanguageId
      })
      .subscribe(
        res => {
          console.log(res);
        },
        err => {
          console.error(err);
        }
      );
  }
}
