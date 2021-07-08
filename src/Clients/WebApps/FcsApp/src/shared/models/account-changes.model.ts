import { AccountCard } from './account-card.model';

export class AccountChanges{
    account: AccountCard;
    changesCurrency: string;
    changesValue: number;

    constructor(account: AccountCard, changesValue: number, changesCurrency: string) {
        this.account = account;
        this.changesValue = changesValue;
        this.changesCurrency = changesCurrency;
    }
}