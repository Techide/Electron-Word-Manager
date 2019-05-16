import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { map } from 'rxjs/operators';
import { DataService } from 'src/app/shared/services/data.service';
import { ICurriculum } from 'src/app/shared/interfaces';

@Injectable({ providedIn: 'root' })
export class CurriculaPageResolver implements Resolve<ICurriculum[]> {

    constructor(private data: DataService) { }

    public resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const id = route.params.id;
        const sortOrder = route.queryParams.sortOrder;
        return this.data.curricula
            .getByRankType(id)
            .pipe(map(curricula => {
                return curricula.sort((a, b) => this.sorting(a, b, sortOrder));
            }));
    }

    private sorting(a: ICurriculum, b: ICurriculum, sortOrder: number) {
        return sortOrder === 1 ? a.Rank - b.Rank : b.Rank - a.Rank;
    }
}
