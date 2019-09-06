import { Component, OnInit, Input } from '@angular/core';
import { BankAccount } from 'src/shared/models/bank-account.model';
import { AccountBalance } from 'src/shared/models/account-balance.model';

@Component({
  selector: 'app-bank-account',
  templateUrl: './bank-account.component.html',
  styleUrls: ['./bank-account.component.scss']
})
export class BankAccountComponent implements OnInit {
  @Input() account: BankAccount;

  constructor() { }

  ngOnInit() {
  }
}
