import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { map, switchMap } from 'rxjs/operators';
import { DataService } from 'src/app/shared/services/data.service';
import { MemoryStorageService } from 'src/app/shared/services/memory-storage.service';
import { ICurriculum } from 'src/app/shared/interfaces';

@Injectable({ providedIn: 'root' })
export class CurriculaPageResolver implements Resolve<ICurriculum[]> {

    constructor(private data: DataService, private storage: MemoryStorageService) { }

    public resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        let id: number;
        let fromServer = false;
        if (this.storage.rank.selectedItem && this.storage.rank.selectedItem.Id) {
            id = this.storage.rank.selectedItem.Id;
        } else {
            id = route.params.id;
            fromServer = true;
        }

        if (fromServer) {
            return this.data.rankTypes.all().pipe(switchMap(rankTypes => {
                this.storage.rank.selectedItem = rankTypes.find(x => x.Id === id);
                return this.data.curricula.getByRankType(id)
                    .pipe(map(curricula => {
                        return curricula.sort((a, b) => this.sorting(a, b));
                    }));
            }));
        } else {
            return this.data.curricula.getByRankType(id).pipe<ICurriculum[]>(
                map(x => {
                    return x.sort((a, b) => this.sorting(a, b));
                })
            );
        }
    }

    private sorting(a: ICurriculum, b: ICurriculum) {
        if (this.storage.rank.selectedItem.SortOrderId === 1) {
            return a.Rank - b.Rank;
        }
        return b.Rank - a.Rank;
    }
}
