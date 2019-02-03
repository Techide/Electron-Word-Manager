import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpResponse,
  HttpErrorResponse
} from '@angular/common/http';
import { BaseRepository } from './base-repository.abstract';
import { ICurriculum } from '../interfaces/curriculum.interface';
import { BehaviorSubject } from 'rxjs';
import { subscribeOn } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CurriculumRepository extends BaseRepository {
  constructor(private client: HttpClient) {
    super('curricula');
  }

  getByRankType(rankTypeId: number) {
    return this.client
      .get<ICurriculum[]>(this.API_URL + '/' + rankTypeId);
  }

  create(curriculum: ICurriculum) {
    return this.client.post<ICurriculum>(this.API_URL, curriculum);
  }

  update(curriculum: ICurriculum) {
    return this.client.put<ICurriculum>(this.API_URL, curriculum);
  }

  delete(id: number) {
    return this.client.delete(this.API_URL + '/' + id);
  }

}
