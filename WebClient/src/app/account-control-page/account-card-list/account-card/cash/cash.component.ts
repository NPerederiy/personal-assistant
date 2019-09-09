import { Component, OnInit, Input } from '@angular/core';
import { CashAccount } from 'src/shared/models/cash-account.model';

@Component({
  selector: 'app-cash',
  templateUrl: './cash.component.html',
  styleUrls: ['./cash.component.scss']
})
export class CashComponent implements OnInit {
  @Input() account: CashAccount;
  showMoreCurrencies: boolean;

  constructor() { }

  ngOnInit() {
    this.showMoreCurrencies = false;
  }

  changeDisplayedCurrenciesCounts(){
    this.showMoreCurrencies = !this.showMoreCurrencies;
  }
}
