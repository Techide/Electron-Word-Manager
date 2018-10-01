import { Injectable } from '@angular/core';
import { CurriculumRepository } from '../repositories/curriculum.repository';
import { RankTypeRepository } from '../repositories/rank-type.repository';
import { PartsRepository } from '../repositories/parts.repository';
import { RankSortOrderRepository } from '../repositories/rank-sort-order.repository';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  constructor(
    public curricula: CurriculumRepository,
    public parts: PartsRepository,
    public rankTypes: RankTypeRepository,
    public RankSortOrdes: RankSortOrderRepository
  ) {}
}
