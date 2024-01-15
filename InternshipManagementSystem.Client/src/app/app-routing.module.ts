import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './admin/layout/layout.component';
import { DashboardComponent } from './admin/components/dashboard/dashboard.component';
import { HomeComponent } from './ui/components/home/home.component';
import { AdvisorsModule } from './admin/components/advisors/advisors.module';

const routes: Routes = [
  {
    path: "admin" , component: LayoutComponent, children: [
    {path: "",component: DashboardComponent},
    {path: "advisors", loadChildren: () => import("./admin/components/advisors/advisors.module").then(module => module.AdvisorsModule)},
    {path: "students", loadChildren: () => import("./admin/components/students/students.module").then(module => module.StudentsModule)},
    ]
  },
  {path: "", component: HomeComponent},
  {path: "formlar", loadChildren: () => import("./ui/components/formlar/formlar.module").then(module => module.FormlarModule)},
  {path: "ig-belge", loadChildren: () => import("./ui/components/ig-belge/ig-belge.module").then(module => module.IgBelgeModule)},
  {path: "staj-def", loadChildren: () => import("./ui/components/staj-def/staj-def.module").then(module => module.StajDefModule)},
  {path: "staj-yon", loadChildren: () => import("./ui/components/staj-yon/staj-yon.module").then(module => module.StajYonModule)},
  {path: "login", loadChildren: () => import("./ui/components/login/login.module").then(module => module.LoginModule)},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
