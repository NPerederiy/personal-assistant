import { Component, OnInit, Input } from '@angular/core';
import { PiggyBankAccount } from 'src/shared/models/piggy-bank-account.model';

@Component({
  selector: 'app-piggy-bank',
  templateUrl: './piggy-bank.component.html',
  styleUrls: ['./piggy-bank.component.scss']
})
export class PiggyBankComponent implements OnInit {
  @Input() account: PiggyBankAccount;

  constructor() { }

  ngOnInit() {
  }

}
