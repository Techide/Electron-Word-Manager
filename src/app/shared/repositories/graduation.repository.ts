import { Injectable } from '@angular/core';
import { BaseRepository } from './base-repository.abstract';
import { HttpClient } from '@angular/common/http';
import { IGraduation } from '../interfaces/IGraduation.interface';

@Injectable({
  providedIn: 'root'
})
export class GraduationRepository extends BaseRepository {
  constructor(private client: HttpClient) {
    super('http://localhost:5000/api/graduations');
  }

  all() {
    return this.client.get<IGraduation[]>(this.API_URL).toPromise();
  }
}
