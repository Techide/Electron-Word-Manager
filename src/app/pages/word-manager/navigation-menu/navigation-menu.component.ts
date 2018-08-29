import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../shared/services/data.service';
import { Observable, pipe } from 'rxjs';
import { IGraduation } from '../../../shared/interfaces/IGraduation.interface';
import { map } from 'rxjs/operators';

@Component({
  selector: 'ewm-navigation-menu',
  templateUrl: './navigation-menu.component.html',
  styleUrls: ['./navigation-menu.component.scss']
})
export class NavigationMenuComponent implements OnInit {
  graduations: IGraduation[];

  constructor(private service: DataService) {}

  ngOnInit(): void {
    this.service.graduations.all().then(
      x => {
        this.graduations = x;
      },
      y => {}
    );
  }
}
