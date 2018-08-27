import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NavigationMenuComponent } from './pages/word-manager/navigation-menu/navigation-menu.component';
import { WordManagerComponent } from './pages/word-manager/word-manager.component';

const routes: Routes = [{ path: '', component: WordManagerComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
