import { Component, Output, EventEmitter } from '@angular/core';
import { Router, ActivatedRoute, Data } from '@angular/router';
import { map } from 'rxjs/operators';
import { ICurriculum } from 'src/app/shared/interfaces/curriculum.interface';
import { DataService } from 'src/app/shared/services/data.service';
import { IPart } from 'src/app/shared/interfaces';

@Component({
  selector: 'ewm-curriculum-page',
  templateUrl: './curriculum-page.component.html',
  styleUrls: ['./curriculum-page.component.scss']
})
export class CurriculumPageComponent {
  selectedCurriculum: ICurriculum | null = null;
  curricula: ICurriculum[] = [];
  parts: IPart[] = [];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private data: DataService,
  ) {
    this.route.data
      .pipe(
        map<Data, ICurriculum[]>(res => {
          return res['curricula'];
        })
      )
      .subscribe(x => {
        this.curricula = x;
      });
  }

  onBackButtonClicked(): void {
    this.router.navigate(['..'], { relativeTo: this.route });
  }

  selectedItemChanged(card: ICurriculum) {
    this.selectedCurriculum = card;
    this.data.parts.getByCurriculumId(card.Id)
      .subscribe(x => {
        this.parts = x;
      });

  }
}
