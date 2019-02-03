import { Injectable } from '@angular/core';
import { IMemproperty, IRankType, ICurriculum, IPart } from '../interfaces';

@Injectable({ providedIn: 'root' })
export class MemoryStorageService {

  public rank: IMemproperty<IRankType> = <IMemproperty<IRankType>> {};

  public curriculum: IMemproperty<ICurriculum> = <IMemproperty<ICurriculum>> {};

  public part: IMemproperty<IPart> = <IMemproperty<IPart>> {};
}
