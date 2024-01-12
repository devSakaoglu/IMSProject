import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { StajYonComponent } from './staj-yon/staj-yon.component';
import { StajDefComponent } from './staj-def/staj-def.component';
import { FormlarComponent } from './formlar/formlar.component';
import { IgBelgeComponent } from './ig-belge/ig-belge.component';
import { LoginComponent } from './login/login.component';

@NgModule({
 declarations: [
    AppComponent,
    HomeComponent,
    StajYonComponent,
    StajDefComponent,
    FormlarComponent,
    IgBelgeComponent,
    LoginComponent
 ],
 imports: [
    BrowserModule,
    RouterModule.forRoot([]),
    AppRoutingModule
 ],
 providers: [],
 bootstrap: [AppComponent],
 schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }