import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { DataService } from 'src/app/shared/services/data.service';
import { MemoryStorageService } from 'src/app/shared/services/memory-storage.service';
import { ICurriculum, IMemproperty } from 'src/app/shared/interfaces';

@Injectable({ providedIn: 'root' })
export class CurriculaPageResolver implements Resolve<Observable<ICurriculum[]>> {

    constructor(private data: DataService, private storage: MemoryStorageService) { }

    public resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ICurriculum[]> {
        return this.data.curricula.getByRankType(this.storage.rank.selectedItem.Id)
            .pipe<ICurriculum[]>(
                map(x => {
                    return x.sort((a, b) => {
                        if (this.storage.rank.selectedItem.SortOrderId === 1) {
                            return a.Rank - b.Rank;
                        }
                        return b.Rank - a.Rank;
                    });
                })
            );
    }
}
