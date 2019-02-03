import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseRepository } from './base-repository.abstract';
import { IPart } from '../interfaces/part.interface';

@Injectable({
  providedIn: 'root'
})
export class PartsRepository extends BaseRepository {
  constructor(private client: HttpClient) {
    super('parts');
  }

  getByCurriculumId(curriculumId: number) {
    return this.client.get<IPart[]>(this.API_URL + '/' + curriculumId);
  }

  delete(id: number): any {
    return this.client.delete(this.API_URL + '/' + id);
  }
}
