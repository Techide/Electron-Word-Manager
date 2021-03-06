import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WordManagerComponent } from './pages/word-manager/word-manager.component';

const routes: Routes = [
  { path: '', component: WordManagerComponent },
  { path: '**', redirectTo: '', pathMatch: 'full', component: WordManagerComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      enableTracing: false
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
