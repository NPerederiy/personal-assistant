import { Component, OnInit, Input } from '@angular/core';
import { Transaction } from 'src/shared/models/transaction.model';
import { CashAccount } from 'src/shared/models/cash-account.model';
import { BankAccount } from 'src/shared/models/bank-account.model';
import { PiggyBankAccount } from 'src/shared/models/piggy-bank-account.model';
import { BankCard } from 'src/shared/models/bank-card-account.model';

@Component({
  selector: 'app-transaction-card',
  templateUrl: './transaction-card.component.html',
  styleUrls: ['./transaction-card.component.scss']
})
export class TransactionCardComponent implements OnInit {
  @Input() transaction: Transaction;

  constructor() { }

  ngOnInit() {
  }

  getBalanceByCurrency(currencyCode: string){
    if (this.transaction.account instanceof CashAccount){
      
    } else if (this.transaction.account instanceof BankCard){
      
    } else if (this.transaction.account instanceof BankAccount){
      
    } else if (this.transaction.account instanceof PiggyBankAccount){
      
    }
    
  }
}
