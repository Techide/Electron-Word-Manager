import { Component, OnInit } from '@angular/core';
import { StorageService } from '../../../shared/services/storage.service';
import { Router, ActivatedRoute } from '@angular/router';
import { IRankType } from '../../../shared/interfaces/rank-type.interface';

@Component({
  selector: 'ewm-curriculum-page',
  templateUrl: './curriculum-page.component.html',
  styleUrls: ['./curriculum-page.component.scss']
})
export class CurriculumPageComponent {
  rankType: any;

  constructor(
    private storageService: StorageService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    if (this.storageService.get(StorageService.Keys.INITIAL_RANK_TYPE)) {
      this.storageService.remove(StorageService.Keys.INITIAL_RANK_TYPE);
    }
  }

  onBackButtonClicked(): void {
    this.router.navigate(['../'], { relativeTo: this.route });
  }
}
