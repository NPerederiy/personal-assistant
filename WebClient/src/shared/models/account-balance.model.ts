export class AccountBalance{
    currencyCode: string;
    balance: number;

    constructor(currencyCode: string, balance?: number) {
        this.currencyCode = currencyCode;
        this.balance = balance || 0.0;
    }
}