import { NgModule } from '@angular/core';

import { WordManagerRoutingModule } from './word-manager-routing.module';
import { CurriculaListComponent } from './curricula-list/curricula-list.component';
import { SharedModule } from '../../shared/shared.module';
import { WordManagerComponent } from './word-manager.component';
import { RankSelectionComponent } from './rank-selection/rank-selection.component';
import { CurriculumDetailsComponent } from './curriculum-details/curriculum-details.component';
import { CurriculumPageComponent } from './curriculum-page/curriculum-page.component';
import { RankTypeFormComponent } from './rank-type-form/rank-type-form.component';
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
export class WordManagerModule {}
