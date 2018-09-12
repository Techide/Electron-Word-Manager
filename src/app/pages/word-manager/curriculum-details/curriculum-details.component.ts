import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../shared/services/data.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { IPart } from '../../../shared/interfaces/part.interface';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'ewm-curriculum-details',
  templateUrl: './curriculum-details.component.html',
  styleUrls: ['./curriculum-details.component.scss']
})
export class CurriculumDetailsComponent implements OnInit {
  parts: IPart[];

  constructor(
    private data: DataService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

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
      });
  }
}