import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../shared/services/data.service';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { IPart } from '../../../shared/interfaces/part.interface';
import { switchMap } from 'rxjs/operators';
import { NavigationService } from 'src/app/shared/services/navigation.service';

@Component({
  selector: 'ewm-curriculum-details',
  templateUrl: './curriculum-details.component.html',
  styleUrls: ['./curriculum-details.component.scss']
})
export class CurriculumDetailsComponent implements OnInit {
  parts: IPart[];
  dataLoaded = false;

  constructor(
    private data: DataService,
    private navigator: NavigationService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.route.paramMap
      .pipe(
        switchMap((x: ParamMap) => {
          const id = parseInt(x.get('id'), 10);
          return this.data.parts.getByCurriculumId(id);
        })
      )
      .subscribe(x => {
        this.parts = x;
        this.dataLoaded = true;
      });
  }

  anyParts(): boolean {
    return this.parts ? this.parts.length >= 1 : false;
  }

  createPartClicked() {
    this.navigator.navigate([{ outlets: { details: 'createpart' } }]);
  }

  isDataLoaded(): boolean {
    return this.dataLoaded;
  }
}
