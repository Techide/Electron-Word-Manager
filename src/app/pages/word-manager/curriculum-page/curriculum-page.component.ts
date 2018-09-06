import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../shared/services/data.service';
import { StorageService } from '../../../shared/services/storage.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'ewm-curriculum-page',
  templateUrl: './curriculum-page.component.html',
  styleUrls: ['./curriculum-page.component.scss']
})
export class CurriculumPageComponent implements OnInit {
  constructor(
    private service: DataService,
    private storage: StorageService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {}

  onBackButtonClicked(): void {
    this.router.navigate(['../'], { relativeTo: this.route });
  }
}
