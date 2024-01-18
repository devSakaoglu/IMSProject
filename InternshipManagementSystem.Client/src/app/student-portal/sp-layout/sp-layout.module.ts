import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpLayoutComponent } from './sp-layout.component';
import { ComponentsModule } from '../components/components.module';
import { RouterModule } from '@angular/router';
import { MatSidenavModule } from '@angular/material/sidenav';
import { SpHeaderComponent } from './components/sp-header/sp-header.component';
import { SpSidebarComponent } from './components/sp-sidebar/sp-sidebar.component';
import { SpFooterComponent } from './components/sp-footer/sp-footer.component';


@NgModule({
    declarations: [
        SpLayoutComponent,
        SpHeaderComponent,
        SpSidebarComponent,
        SpFooterComponent
    ],
    imports: [
        CommonModule,
        ComponentsModule,
        RouterModule,
        MatSidenavModule,
    ],
    exports: [
        SpLayoutComponent
    ]
})
export class SpLayoutModule { }
