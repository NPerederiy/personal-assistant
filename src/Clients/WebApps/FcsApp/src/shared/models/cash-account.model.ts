import { AccountCard } from './account-card.model';
import { AccountBalance } from './account-balance.model';

export class CashAccount extends AccountCard{
    balances: AccountBalance[];

    constructor(name: string, balances: AccountBalance[], id?: string) {
        super(name, id);

        this.balances = balances;
    }
}