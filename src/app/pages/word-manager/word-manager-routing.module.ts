import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RankTypeFormComponent } from './rank-type-form/rank-type-form.component';
import { CurriculumPageComponent } from './curriculum-page/curriculum-page.component';
import { CurriculumFormComponent } from './curriculum-form/curriculum-form.component';
import { PartFormComponent } from './part-form/part-form.component';
import { RankSelectionComponent } from './rank-selection/rank-selection.component';
import { RankSelectionResolver } from './rank-selection/rank-selection.resolver';
import { CurriculaPageResolver } from './curriculum-page/curriculum-page.resolver';
import { RankTypeFormResolver } from './rank-type-form/rank-type-form.resolver';

const routes: Routes = [
  { path: '', component: RankSelectionComponent, resolve: { ranks: RankSelectionResolver } },
  { path: 'curricula/:id', component: CurriculumPageComponent, resolve: { curricula: CurriculaPageResolver } },
  { path: 'ranktype/edit', component: RankTypeFormComponent, resolve: { ranksortorders: RankTypeFormResolver } },
  { path: 'curriculum/edit', component: CurriculumFormComponent, outlet: 'modal' },
  { path: 'part/edit', component: PartFormComponent, outlet: 'modal' },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WordManagerRoutingModule { }
