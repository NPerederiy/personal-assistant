import { AccountCard } from './account-card.model';
import { AccountChanges } from './account-changes.model';

export class Transaction{
    description: string;
    accountChanges: AccountChanges[]; 
    date: string;

    // account: AccountCard;
    // debitCurrency: string;
    // debitValue: number;
    // creditCurrency: string;
    // creditValue: number;

    constructor(descr: string, accountChanges: AccountChanges[], date: string) {
        this.description = descr;
        this.accountChanges = accountChanges;
        this.date = date;
    }

    // constructor(descr: string, account: AccountCard, debitCurrency: string, debitValue: number, creditCurrency: string, creditValue: number, date: string) {
    //     this.description = descr;
    //     this.account = account;
    //     this.debitCurrency = debitCurrency;
    //     this.debitValue = debitValue;
    //     this.creditCurrency = creditCurrency;
    //     this.creditValue = creditValue;
    //     this.date = date;
    // }
}