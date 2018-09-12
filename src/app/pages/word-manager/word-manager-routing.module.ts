import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WordManagerComponent } from './word-manager.component';
import { RankSelectionComponent } from './rank-selection/rank-selection.component';
import { CurriculumPageComponent } from './curriculum-page/curriculum-page.component';
import { CurriculumDetailsComponent } from './curriculum-details/curriculum-details.component';

const routes: Routes = [
  {
    path: '',
    component: WordManagerComponent,
    children: [
      { path: '', component: RankSelectionComponent },
      {
        path: 'curriculum',
        component: CurriculumPageComponent,
        children: [
          {
            path: ':id',
            component: CurriculumDetailsComponent,
            outlet: 'details'
          }
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WordManagerRoutingModule {}
