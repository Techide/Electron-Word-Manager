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
  // private _curricula: BehaviorSubject<ICurriculum[]>;
  // private _dataStore: { curricula: ICurriculum[] };

  constructor(private client: HttpClient) {
    super('http://localhost:5000/api/curricula');
    // this._dataStore = { curricula: [] };
    // this._curricula = new BehaviorSubject<ICurriculum[]>([]);
  }

  // get observable() {
  //   return this._curricula.asObservable();
  // }

  // get count(): number {
  //   return this._dataStore.curricula.length;
  // }

  getByRankType(rankTypeId: number) {
    return this.client
      .get<ICurriculum[]>(this.API_URL + '/' + rankTypeId, {})
      .toPromise();
    // .subscribe(
    //   x => {
    //     this._dataStore.curricula = x;
    //     this._curricula.next(Object.assign({}, this._dataStore).curricula);
    //   },
    //   e => {
    //     this.handleError(e);
    //   }
    // );
  }

  create(curriculum: ICurriculum) {
    return this.client.post<ICurriculum>(this.API_URL, curriculum).toPromise();
    // .subscribe(
    //   x => {
    //     this._dataStore.curricula.push(x);
    //     this._curricula.next(Object.assign({}, this._dataStore).curricula);
    //   },
    //   e => {
    //     this.handleError(e);
    //   }
    // );
  }

  update(curriculum: ICurriculum) {
    return this.client.put<ICurriculum>(this.API_URL, curriculum).toPromise();
    // .subscribe(
    //   x => {
    //     this._dataStore.curricula.forEach((t, i) => {
    //       if (t.Id === x.Id) {
    //         this._dataStore.curricula[i] = x;
    //       }
    //     });
    //   },
    //   e => {
    //     this.handleError(e);
    //   }
    // );
  }

  delete(id: number) {
    return this.client.delete(this.API_URL + '/' + id).toPromise();
    // .subscribe(
    //   x => {
    //     this._dataStore.curricula.forEach((t, i) => {
    //       if (t.Id === id) {
    //         this._dataStore.curricula.splice(i, 1);
    //         this._curricula.next(Object.assign({}, this._dataStore).curricula);
    //       }
    //     });
    //   },
    //   e => {
    //     this.handleError(e);
    //   }
    // );
  }

  private handleError(e: HttpErrorResponse) {
    console.error(e);
  }
}
