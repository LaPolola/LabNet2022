import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShippersComponent } from './shippers.component';
import { ShowShipperComponent } from './components/show-shipper/show-shipper.component';
import { AddEditShipperComponent } from './components/add-edit-shipper/add-edit-shipper.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ShippersComponent,
    ShowShipperComponent,
    AddEditShipperComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule
  ]
})
export class ShippersModule { }
