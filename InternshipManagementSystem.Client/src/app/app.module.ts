import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminModule } from './admin/admin.module';
import { UiModule } from './ui/ui.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { StudentPortalModule } from './student-portal/student-portal.module';
import { AdvisorPortalModule } from './advisor-portal/advisor-portal.module';
import { NgxSpinnerModule } from 'ngx-spinner';
import { HttpClientModule } from '@angular/common/http';
import { NavbarComponent } from './navbar/navbar.component';



@NgModule({
  declarations: [
    AppComponent,
<<<<<<< HEAD
    NavbarComponent,
=======
>>>>>>> 9f102ca6b93483f051c1450aa2668731e77f19c7

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    AdminModule, UiModule, 
    StudentPortalModule,
    AdvisorPortalModule,
    NgxSpinnerModule,
    HttpClientModule,    
    AdvisorPortalModule,
    NgxSpinnerModule,
    HttpClientModule,    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
