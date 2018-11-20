import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseRepository } from './base-repository.abstract';
import { IRankType } from '../interfaces/rank-type.interface';

@Injectable({
  providedIn: 'root'
})
export class RankTypeRepository extends BaseRepository {
  constructor(private client: HttpClient) {
    super('ranktypes');
  }

  all(): Promise<IRankType[]> {
    return this.client.get<IRankType[]>(this.API_URL).toPromise();
  }

  async delete(id: number): Promise<void> {
    this.client.delete(this.API_URL + `/${id}`).toPromise();
  }
}
