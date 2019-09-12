import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  isNewUser: boolean;

  constructor(private router: Router) { 
    this.openSignIn();
  }

  ngOnInit() {
  }

  openSignIn(){
    this.isNewUser = false;
  }

  openSignUp(){
    this.isNewUser = true;
  }

  submit(){
    this.router.navigateByUrl('/accounts');
  }

}
