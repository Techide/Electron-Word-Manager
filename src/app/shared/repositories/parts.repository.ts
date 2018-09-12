import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseRepository } from './base-repository.abstract';
import { ICurriculum } from '../interfaces/curriculum.interface';
import { IPart } from '../interfaces/part.interface';

@Injectable({
  providedIn: 'root'
})
export class PartsRepository extends BaseRepository {
  constructor(private client: HttpClient) {
    super('http://localhost:5000/api/parts');
  }

  getByCurriculumId(curriculumId: number): Promise<IPart[]> {
    return this.client
      .get<IPart[]>(this.API_URL + '/' + curriculumId, {})
      .toPromise<IPart[]>();
  }
}
