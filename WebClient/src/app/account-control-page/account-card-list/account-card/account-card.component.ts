import { Component, OnInit, Input } from '@angular/core';
import { AccountCard } from 'src/shared/models/account-card.model';
import { BankAccount } from 'src/shared/models/bank-account.model';
import { CashAccount } from 'src/shared/models/cash-account.model';
import { PiggyBankAccount } from 'src/shared/models/piggy-bank-account.model';
import { BankCard } from 'src/shared/models/bank-card-account.model';

@Component({
  selector: 'app-account-card',
  templateUrl: './account-card.component.html',
  styleUrls: ['./account-card.component.scss']
})

export class AccountCardComponent implements OnInit {
  @Input() account: AccountCard; 

  constructor() { }

  ngOnInit() {
  }

  public IsBankAccount(){
    return this.account instanceof BankAccount;
  }

  public IsBankCard(){ 
    return this.account instanceof BankCard;
  }

  public IsPiggyBank(){
    return this.account instanceof PiggyBankAccount;
  }

  public IsCash(){
    return this.account instanceof CashAccount;
  }
}
