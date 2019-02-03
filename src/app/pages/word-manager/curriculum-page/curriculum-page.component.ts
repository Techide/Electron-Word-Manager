import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
import { ICurriculum } from 'src/app/shared/interfaces/curriculum.interface';
import { MemoryStorageService } from 'src/app/shared/services/memory-storage.service';

@Component({
  selector: 'ewm-curriculum-page',
  templateUrl: './curriculum-page.component.html',
  styleUrls: ['./curriculum-page.component.scss']
})
export class CurriculumPageComponent {
  selectedCurriculum: ICurriculum;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    public storage: MemoryStorageService
  ) {
    this.route.data.pipe(map(res => {
      return res['curricula'];
    }))
      .subscribe((x: ICurriculum[]) => {
        this.storage.curriculum.items = x;
      });
  }

  onBackButtonClicked(): void {
    this.router.navigate(['..'], { relativeTo: this.route });
  }
}
