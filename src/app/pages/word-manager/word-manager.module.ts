import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { WordManagerRoutingModule } from './word-manager-routing.module';
import { WordManagerComponent } from './word-manager.component';
import { RankSelectionComponent } from './rank-selection/rank-selection.component';
import { RankTypeFormComponent } from './rank-type-form/rank-type-form.component';
import { CurriculumPageComponent } from './curriculum-page/curriculum-page.component';
import { CurriculaListComponent } from './curricula-list/curricula-list.component';
import { CurriculumDetailsComponent } from './curriculum-details/curriculum-details.component';
import { CurriculumFormComponent } from './curriculum-form/curriculum-form.component';
import { PartFormComponent } from './part-form/part-form.component';

@NgModule({
  imports: [SharedModule, WordManagerRoutingModule],
  declarations: [
    WordManagerComponent,
    RankSelectionComponent,
    RankTypeFormComponent,
    CurriculumPageComponent,
    CurriculaListComponent,
    CurriculumDetailsComponent,
    CurriculumFormComponent,
    PartFormComponent
  ]
})
export class WordManagerModule { }
