import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CurriculaListComponent } from './pages/word-manager/curricula-list/curricula-list.component';
import { WordManagerComponent } from './pages/word-manager/word-manager.component';

const routes: Routes = [{ path: '', component: WordManagerComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
