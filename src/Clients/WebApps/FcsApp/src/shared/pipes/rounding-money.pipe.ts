import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'money'
})
export class RoundingMoneyPipe implements PipeTransform {
  transform(value: number, accuracy?: number): string {
    if (isNaN(accuracy)){
        return this.gaussRound(value, 2).toFixed(2);
    } else if (accuracy === 0){
        return Math.trunc(value).toFixed(0);
    } else {
        return this.gaussRound(value, accuracy).toFixed(accuracy);
    }    
  }

  private gaussRound(num: number, decimalPlaces: number) {
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