import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CurriculumRankTypeListComponent } from './pages/word-manager/curriculum-rank-type-list/curriculum-rank-type-list.component';
import { WordManagerComponent } from './pages/word-manager/word-manager.component';

const routes: Routes = [{ path: '', component: WordManagerComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
