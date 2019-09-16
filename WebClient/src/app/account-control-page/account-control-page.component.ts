import { Component, OnInit } from '@angular/core';
import { AccountCard } from 'src/shared/models/account-card.model';
import { BankCard } from 'src/shared/models/bank-card-account.model';
import { PaymentSystem } from 'src/shared/models/payment-system.enum';
import { PiggyBankAccount } from 'src/shared/models/piggy-bank-account.model';
import { CashAccount } from 'src/shared/models/cash-account.model';
import { AccountBalance } from 'src/shared/models/account-balance.model';
import { BankAccount } from 'src/shared/models/bank-account.model';
import { Transaction } from 'src/shared/models/transaction.model';
import { AccountChanges } from 'src/shared/models/account-changes.model';

@Component({
  selector: 'app-account-control-page',
  templateUrl: './account-control-page.component.html',
  styleUrls: ['./account-control-page.component.scss']
})
export class AccountControlPageComponent implements OnInit {
  accounts: AccountCard[] = [];
  transactionHistory: Transaction[] = [];
  
  constructor() {

    let cash_account = new CashAccount(
      "Cash", 
      [
        new AccountBalance("UAH", 1407),
        new AccountBalance("RUB", 32.1451),
        new AccountBalance("UAH", 17000.14124),
        new AccountBalance("RUB", 635.00),
        new AccountBalance("HUF", 42.80124)
      ]
    );

    this.accounts.push(
      cash_account,
      new BankCard(
        "monobank | Universal Bank", 
        "5375 4141 0000 0000", 
        "04 / 24", 
        PaymentSystem.mastercard, 
        new AccountBalance("UAH",6054.124903)
      ),
      new BankCard(
        "UKRSIBBANK",
        "5351 2801 0000 0000", 
        "06 / 22", 
        PaymentSystem.mastercard, 
        new AccountBalance("UAH")
      ),
      new BankAccount(
        "UKRSIBBANK UAH",
        "UA0000000000000000000000000",
        new AccountBalance("UAH", 651.488)
      ),
      new BankCard(
        "PrivatBank",
        "5168 7573 6971 7758", 
        "05 / 22", 
        PaymentSystem.visa, 
        new AccountBalance("UAH",864.17924)
      ),
      new PiggyBankAccount(
        "Piggy bank", 
        [
          new AccountBalance("USD", 10.01),
          new AccountBalance("EUR", 322.23),
          new AccountBalance("UAH", 17000.14124),
          new AccountBalance("RUB", 635.00),
          new AccountBalance("HUF", 42.80124)
        ]
      )
    );

    this.transactionHistory.push(
      new Transaction(
        "[Bank] Curency exchange",
        [
          new AccountChanges(cash_account, -400.00, "USD"),
          new AccountChanges(cash_account, 9878.20, "UAH"),
        ],
        "09.13.2019"
      ),
      new Transaction(
        "[Bank] Curency exchange",
        [
          new AccountChanges(cash_account, -400.00, "USD"),
          new AccountChanges(cash_account, 9878.20, "UAH"),
        ],
        "09.13.2019"
      ),
      new Transaction(
        "[Bank] Curency exchange",
        [
          new AccountChanges(cash_account, -400.00, "USD"),
          new AccountChanges(cash_account, 9878.20, "UAH"),
        ],
        "09.13.2019"
      ),
      new Transaction(
        "[Bank] Curency exchange",
        [
          new AccountChanges(cash_account, -400.00, "USD"),
          new AccountChanges(cash_account, 9878.20, "UAH"),
        ],
        "09.13.2019"
      ),
      new Transaction(
        "[Bank] Curency exchange",
        [
          new AccountChanges(cash_account, -400.00, "USD"),
          new AccountChanges(cash_account, 9878.20, "UAH"),
        ],
        "09.13.2019"
      ),
      new Transaction(
        "[Bank] Curency exchange",
        [
          new AccountChanges(cash_account, -400.00, "USD"),
          new AccountChanges(cash_account, 9878.20, "UAH"),
        ],
        "09.13.2019"
      ),
      new Transaction(
        "[Bank] Curency exchange",
        [
          new AccountChanges(cash_account, -400.00, "USD"),
          new AccountChanges(cash_account, 9878.20, "UAH"),
        ],
        "09.13.2019"
      ),
      new Transaction(
        "[Bank] Curency exchange",
        [
          new AccountChanges(cash_account, -400.00, "USD"),
          new AccountChanges(cash_account, 9878.20, "UAH"),
        ],
        "09.13.2019"
      ),
      new Transaction(
        "[Bank] Curency exchange",
        [
          new AccountChanges(cash_account, -400.00, "USD"),
          new AccountChanges(cash_account, 9878.20, "UAH"),
        ],
        "09.13.2019"
      ),
      new Transaction(
        "[Bank] Curency exchange",
        [
          new AccountChanges(cash_account, -400.00, "USD"),
          new AccountChanges(cash_account, 9878.20, "UAH"),
        ],
        "09.13.2019"
      ),
      new Transaction(
        "[Bank] Curency exchange",
        [
          new AccountChanges(cash_account, -400.00, "USD"),
          new AccountChanges(cash_account, 9878.20, "UAH"),
        ],
        "09.13.2019"
      ),
      new Transaction(
        "[Bank] Curency exchange",
        [
          new AccountChanges(cash_account, -400.00, "USD"),
          new AccountChanges(cash_account, 9878.20, "UAH"),
        ],
        "09.13.2019"
      ),
      new Transaction(
        "[Bank] Curency exchange",
        [
          new AccountChanges(cash_account, -400.00, "USD"),
          new AccountChanges(cash_account, 9878.20, "UAH"),
        ],
        "09.13.2019"
      ),
      new Transaction(
        "[Bank] Curency exchange",
        [
          new AccountChanges(cash_account, -400.00, "USD"),
          new AccountChanges(cash_account, 9878.20, "UAH"),
        ],
        "09.13.2019"
      ),
      new Transaction(
        "[Bank] Curency exchange",
        [
          new AccountChanges(cash_account, -400.00, "USD"),
          new AccountChanges(cash_account, 9878.20, "UAH"),
        ],
        "09.13.2019"
      )
    );
  }

  ngOnInit() {
  }

}
