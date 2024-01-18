import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApLayoutComponent } from './ap-layout.component';
import { RouterModule } from '@angular/router';
import { MatSidenavModule } from '@angular/material/sidenav';
import { ComponentsModule } from '../components/components.module';
import { ApHeaderComponent } from './components/ap-header/ap-header.component';
import { ApSidebarComponent } from './components/ap-sidebar/ap-sidebar.component';
import { ApFooterComponent } from './components/ap-footer/ap-footer.component';



@NgModule({
  declarations: [
    ApLayoutComponent,
    ApHeaderComponent,
    ApSidebarComponent,
    ApFooterComponent
  ],
  imports: [
    CommonModule,
    ComponentsModule,
    RouterModule,
    MatSidenavModule
  ],
  exports: [
    ApLayoutComponent
  ]
})
export class ApLayoutModule { }
