import { AccountCard } from './account-card.model';

export class Transaction{
    description: string;
    account: AccountCard;
    debitCurrency: string;
    debitValue: number;
    creditCurrency: string;
    creditValue: number;
    date: string;

    constructor(descr: string, account: AccountCard, debitCurrency: string, debitValue: number, creditCurrency: string, creditValue: number, date: string) {
        this.description = descr;
        this.account = account;
        this.debitCurrency = debitCurrency;
        this.debitValue = debitValue;
        this.creditCurrency = creditCurrency;
        this.creditValue = creditValue;
        this.date = date;
    }
}