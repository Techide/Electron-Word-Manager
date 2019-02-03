import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { IRankSortOrder } from 'src/app/shared/interfaces';
import { DataService } from 'src/app/shared/services/data.service';

@Injectable({ providedIn: 'root' }) export class RankTypeFormResolver implements Resolve<IRankSortOrder[]> {

    constructor(private data: DataService) { }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        return this.data.RankSortOrdes.all();
    }

}
