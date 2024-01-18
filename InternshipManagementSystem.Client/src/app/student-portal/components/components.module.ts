import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentInfoModule } from './student-info/student-info.module';
import { StudentIntershipApprovalModule } from './student-intership-approval/student-intership-approval.module';
import { StudentIntershipNotebookModule } from './student-intership-notebook/student-intership-notebook.module';
import { HeaderComponent } from '../layout/components/header/header.component';
import { SidebarComponent } from '../layout/components/sidebar/sidebar.component';
import { FooterComponent } from '../layout/components/footer/footer.component';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    StudentInfoModule,
    StudentIntershipApprovalModule,
    StudentIntershipNotebookModule
  ],
  

})
export class ComponentsModule { }
