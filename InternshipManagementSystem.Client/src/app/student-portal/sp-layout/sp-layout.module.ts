import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpLayoutComponent } from './sp-layout.component';
import { ComponentsModule } from '../components/components.module';
import { RouterModule } from '@angular/router';
import {MatSidenavModule} from '@angular/material/sidenav';


@NgModule({
    declarations: [
        SpLayoutComponent,
    ],
    imports: [
        CommonModule,
        ComponentsModule,
        RouterModule,
        MatSidenavModule
      
    ],
    exports: [
        SpLayoutComponent
    ]
})
export class SpLayoutModule { }
