import { Component ,OnInit} from '@angular/core';
import { UserService } from '../../../services/user.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from '../../../base/base.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent extends BaseComponent implements OnInit {
  userService: any;

  constructor(userService: UserService, spinner: NgxSpinnerService){
    super(spinner)
    
  }
  ngOnInit(): void{}

    async login(StudentNo: string, Password: string, UserName: string){
      this.showSpinner(SpinnerType.BallNewton)
      await this.userService.login(UserName,Password,StudentNo, ()=> this.hideSpinner(SpinnerType.BallNewton));

    }
  

  

}
