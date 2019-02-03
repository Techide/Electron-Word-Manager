import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { DataService } from 'src/app/shared/services/data.service';
import { IRankType } from 'src/app/shared/interfaces/rank-type.interface';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class RankSelectionResolver implements Resolve<Observable<IRankType[]>> {

    constructor(private data: DataService) { }

    public resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<IRankType[]> {
        return this.data.rankTypes.all();
    }
}
