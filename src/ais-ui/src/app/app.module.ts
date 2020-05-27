import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { CoreRouttingModule } from './core/core-routtings.module';
import { ModalModule } from 'ngx-bootstrap/modal';
import { StatesComponent } from './preminum-finance/partial/states/states.component';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { CreateStateComponent } from './preminum-finance/partial/create-state/create-state.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { VersionsComponent } from './preminum-finance/partial/versions/versions.component';
import { VersionComponent } from './preminum-finance/partial/version/version.component';
import { AgenciesComponent } from './preminum-finance/partial/agencies/agencies.component';
import { UnitTreeComponent } from './preminum-finance/partial/unit-tree/unit-tree.component';
import { MarketsComponent } from './preminum-finance/partial/markets/markets.component';
import { ContextMenuModule } from '@ctrl/ngx-rightclick';
import { AgencyRateComponent } from './preminum-finance/partial/agency-rate/agency-rate.component';
import { EditStateComponent } from './preminum-finance/partial/edit-state/edit-state.component';
import { ConfirmDialogComponent } from './core/partial/confirm-dialog/confirm-dialog/confirm-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';



@NgModule({
  declarations: [
    AppComponent,
    StatesComponent,
    CreateStateComponent,
    VersionsComponent,
    VersionComponent,
    AgenciesComponent,
    UnitTreeComponent,
    MarketsComponent,
    EditStateComponent,
    ConfirmDialogComponent
  ],
  imports: [
    ReactiveFormsModule,
    FormsModule,
    NgxDatatableModule,
    BrowserModule,
    MatDialogModule,
    ModalModule.forRoot(),
    BrowserAnimationsModule,
    NoopAnimationsModule,
    ContextMenuModule,
    TabsModule.forRoot(),
    BsDropdownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    HttpClientModule,
    CoreRouttingModule,
    AppRoutingModule

  ],
  entryComponents: [AgencyRateComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
