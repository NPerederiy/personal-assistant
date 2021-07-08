import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.scss']
})
export class MainMenuComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  openProfilePopup(){
    // TODO: implement
    console.log("open Profile popup");
  }

  navigateToAccounts(){
    this.router.navigateByUrl('/accounts');
  }

  navigateToIncomes(){
    this.router.navigateByUrl('/incomes');
  }

  navigateToCosts(){
    this.router.navigateByUrl('/costs');
  }
}
