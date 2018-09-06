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

  getByRankType(rankTypeId: number) {
    this.client.post(this.API_URL, { id: rankTypeId }).toPromise();
  }
}
