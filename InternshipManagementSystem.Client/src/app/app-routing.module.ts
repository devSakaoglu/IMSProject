import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './admin/layout/layout.component';
import { DashboardComponent } from './admin/components/dashboard/dashboard.component';
import { HomeComponent } from './ui/components/home/home.component';
import { AdvisorsModule } from './admin/components/advisors/advisors.module';
import { StudentInfoComponent } from './student-portal/components/student-info/student-info.component';

const routes: Routes = [
  {
    path: "admin", component: LayoutComponent, children: [
      { path: "", component: DashboardComponent },
      { path: "advisors", loadChildren: () => import("./admin/components/advisors/advisors.module").then(module => module.AdvisorsModule) },
      { path: "students", loadChildren: () => import("./admin/components/students/students.module").then(module => module.StudentsModule) },
    ]
  },
  { path: "", component: HomeComponent },
  { path: "formlar", loadChildren: () => import("./ui/components/formlar/formlar.module").then(module => module.FormlarModule) },
  { path: "ig-belge", loadChildren: () => import("./ui/components/ig-belge/ig-belge.module").then(module => module.IgBelgeModule) },
  { path: "staj-def", loadChildren: () => import("./ui/components/staj-def/staj-def.module").then(module => module.StajDefModule) },
  { path: "staj-yon", loadChildren: () => import("./ui/components/staj-yon/staj-yon.module").then(module => module.StajYonModule) },
  { path: "login", loadChildren: () => import("./ui/components/login/login.module").then(module => module.LoginModule) },

  { 
    path: "student-portal", component: LayoutComponent, children: [
      { path: "student-info", loadChildren: () => import("./student-portal/components/student-info/student-info.module").then(module => module.StudentInfoModule) },
      { path: "student-intership-approval", loadChildren: () => import("./student-portal/components/student-intership-approval/student-intership-approval.module").then(module => module.StudentIntershipApprovalModule) },
      {path: "student-intership-info", loadChildren: ()=> import("./student-portal/components/student-intership-info/student-intership-info.module").then(module => module.StudentIntershipInfoModule)},
      {path: "student-intership-notebook", loadChildren: ()=> import("./student-portal/components/student-intership-notebook/student-intership-notebook.module").then(module=> module.StudentIntershipNotebookModule)}
    ]
  }  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
