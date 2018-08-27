import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WordManagerComponent } from './word-manager.component';
import { NavigationMenuComponent } from './navigation-menu/navigation-menu.component';

const routes: Routes = [
  {
    path: '',
    component: WordManagerComponent,
    children: [{ path: '', component: NavigationMenuComponent }]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WordManagerRoutingModule {}
