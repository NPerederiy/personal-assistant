import { Component, OnInit, Input } from '@angular/core';
import { Transaction } from 'src/shared/models/transaction.model';

@Component({
  selector: 'app-transaction-history',
  templateUrl: './transaction-history.component.html',
  styleUrls: ['./transaction-history.component.scss']
})
export class TransactionHistoryComponent implements OnInit {
  @Input() transactions: Transaction[];

  displayFilters: boolean;

  constructor() { 
    this.displayFilters = false;
  }

  ngOnInit() {
  }

  toggleFilters(){
    let filters = document.getElementsByClassName('filters') as HTMLCollectionOf<HTMLElement>;
    let transactions = document.getElementsByClassName('transactions') as HTMLCollectionOf<HTMLElement>;

    if (filters.length != 0 && transactions.length != 0) {
      filters[0].style.display = !this.displayFilters ? "flex" : "none";
      transactions[0].style.maxHeight = !this.displayFilters ? "calc(100vh - 452.5px)" : "calc(100vh - 412.5px)";
      this.displayFilters = !this.displayFilters;
    }
  }

}
