import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseRepository } from './base-repository.abstract';
import { ICurriculum } from '../interfaces/curriculum.interface';

@Injectable({
  providedIn: 'root'
})
export class CurriculumRepository extends BaseRepository {
  constructor(private client: HttpClient) {
    super('http://localhost:5000/api/curricula');
  }

  getByRankType(rankTypeId: number): Promise<ICurriculum[]> {
    return this.client
      .get<ICurriculum[]>(this.API_URL + '/' + rankTypeId, {})
      .toPromise<ICurriculum[]>();
  }

  create(curriculum: ICurriculum) {
    return this.client.post(this.API_URL, curriculum).toPromise();
  }
}
