import { Component, OnInit, Input } from '@angular/core';
import { BankCard } from 'src/shared/models/bank-card-account.model';
import { AccountBalance } from 'src/shared/models/account-balance.model';

@Component({
  selector: 'app-bank-card',
  templateUrl: './bank-card.component.html',
  styleUrls: ['./bank-card.component.scss']
})
export class BankCardComponent implements OnInit {
  @Input() account: BankCard;

  constructor() { }

  ngOnInit() {
    if (!this.account.paymentSystem) {
      this.getCardInfo();
    }
  }

  private getCardInfo(){
    // make a request to an API to get a payment system and other data 

    // use account.number
  }
}
