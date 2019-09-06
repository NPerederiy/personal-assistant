import { AccountCard } from './account-card.model';
import { PaymentSystem } from './payment-system.enum';
import { AccountBalance } from './account-balance.model';

export class BankCard extends AccountCard{
    cardNumber: string;
    validThru: string;
    paymentSystem: PaymentSystem;
    accountBalance: AccountBalance;

    constructor(name: string, number: string, validThru: string, paymentSystem: PaymentSystem, balance: AccountBalance, id?: string) {
        super(name, id);

        this.cardNumber = number;
        this.validThru = validThru;
        this.paymentSystem = paymentSystem;
        this.accountBalance = balance;
    }
}