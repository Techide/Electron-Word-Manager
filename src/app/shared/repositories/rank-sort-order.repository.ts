import { BaseRepository } from './base-repository.abstract';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IRankSortOrder } from '../interfaces/rank-sort-order.interface';

@Injectable({
  providedIn: 'root'
})
export class RankSortOrderRepository extends BaseRepository {
  constructor(private client: HttpClient) {
    super('http://localhost:5000/api/ranksortorder');
  }

  all(): Promise<IRankSortOrder[]> {
    return this.client.get<IRankSortOrder[]>(this.API_URL).toPromise();
  }
}
