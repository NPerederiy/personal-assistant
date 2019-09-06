export class AccountBalance{
    currencyCode: string;
    balance: number;

    constructor(currencyCode: string, balance?: number) {
        this.currencyCode = currencyCode;
        this.balance = balance || 0.0;
    }
    
    getBalanceWithoutCoins(): string {
        return Math.trunc(this.balance).toFixed(2);
    }
    
    getBalanceWithCoins(): string {
        return  this.gaussRound(this.balance,2).toFixed(2);
    }

    private gaussRound(num, decimalPlaces) {
        let d = decimalPlaces || 0,
        m = Math.pow(10, d),
        n = +(d ? num * m : num).toFixed(8),
        i = Math.floor(n), f = n - i,
        e = 1e-8,
        r = (f > 0.5 - e && f < 0.5 + e) ?
            ((i % 2 == 0) ? i : i + 1) : Math.round(n);
        return d ? r / m : r;
    }
}