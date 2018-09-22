import { Injectable } from '@angular/core';
import * as underlyingStorage from '../helpers/local-storage.helper';
@Injectable({
  providedIn: 'root'
})
export class StorageService {
  public static Keys = {
    RANK_TYPE: 'rank-type',
    INITIAL_RANK_TYPE: 'initial-rank-type',
    EDITING_ITEM: 'editing-item'
  };

  constructor() {}

  public get(key: string): any {
    return underlyingStorage.get(key);
  }

  public set(key: string, value: any): void {
    underlyingStorage.set(key, value);
  }

  public remove(key: string): void {
    underlyingStorage.remove(key);
  }

  public clear(): void {
    underlyingStorage.clear();
  }
}
