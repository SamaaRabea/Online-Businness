import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SideNavComponent } from './side-nav/side-nav.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { HeaderComponent } from './header/header.component';
import { RouterModule, Routes } from '@angular/router';
import { MatMenuModule } from '@angular/material/menu';
import { ProductsComponent } from '../Products/Products.component';
import { DashboardComponent } from '../dashboard/dashboard.component';
import {FormsModule,  } from '@angular/forms';
import { FilterPipe } from '../pipes/filter.pipe';

const routes: Routes = [
  { path: '', component: ProductsComponent },
  { path: 'Products', component: ProductsComponent },
  { path: 'Dashboard', component: DashboardComponent },

];

@NgModule({
  declarations: [
    SideNavComponent,
    HeaderComponent,
    ProductsComponent,
    DashboardComponent,
    FilterPipe
  ],
  imports: [
    FormsModule,
    CommonModule,
    MatToolbarModule,
    MatSidenavModule,
    MatButtonModule,
    MatIconModule,
    MatDividerModule,
    MatMenuModule,
    RouterModule.forRoot(routes)
  ],exports:[
    SideNavComponent,
    RouterModule,
    HeaderComponent
  ]
})
export class SharedModule { }
