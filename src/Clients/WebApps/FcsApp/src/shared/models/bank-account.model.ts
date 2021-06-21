import { AccountCard } from './account-card.model';
import { AccountBalance } from './account-balance.model';

export class BankAccount extends AccountCard{
    accountNumber: string;
    accountBalance: AccountBalance;

    constructor(name: string, number: string, balance: AccountBalance, id?: string) {
        super(name, id);

        this.accountNumber = number;
        this.accountBalance = balance;
    }
}