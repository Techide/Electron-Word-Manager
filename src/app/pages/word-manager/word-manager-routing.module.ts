import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WordManagerComponent } from './word-manager.component';
import { RankSelectionComponent } from './rank-selection/rank-selection.component';
import { CurriculumPageComponent } from './curriculum-page/curriculum-page.component';
import { CurriculumDetailsComponent } from './curriculum-details/curriculum-details.component';
import { CurriculumFormComponent } from './curriculum-form/curriculum-form.component';
import { CurriculaListComponent } from './curricula-list/curricula-list.component';
import { RankTypeFormComponent } from './rank-type-form/rank-type-form.component';

const routes: Routes = [
  {
    path: '',
    component: WordManagerComponent,
    children: [
      { path: '', component: RankSelectionComponent },
      { path: 'create', component: RankTypeFormComponent },
      { path: 'edit', component: RankTypeFormComponent },
      {
        path: 'curriculum',
        component: CurriculumPageComponent,
        children: [
          {
            path: '',
            component: CurriculaListComponent
          },
          {
            path: ':id',
            component: CurriculumDetailsComponent,
            outlet: 'details'
          }
        ]
      },
      {
        path: 'curriculum/create',
        component: CurriculumFormComponent
      },
      {
        path: 'curriculum/edit',
        component: CurriculumFormComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WordManagerRoutingModule {}
