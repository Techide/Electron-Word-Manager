import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'ewm-curriculum-page',
  templateUrl: './curriculum-page.component.html',
  styleUrls: ['./curriculum-page.component.scss']
})
export class CurriculumPageComponent {
  rankType: any;

  constructor(private router: Router, private route: ActivatedRoute) {}

  onBackButtonClicked(): void {
    this.router.navigate(['../'], { relativeTo: this.route });
  }
}
