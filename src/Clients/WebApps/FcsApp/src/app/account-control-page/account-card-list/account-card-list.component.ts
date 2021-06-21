import { Component, OnInit, Input } from '@angular/core';
import { AccountCard } from 'src/shared/models/account-card.model';

@Component({
  selector: 'app-account-card-list',
  templateUrl: './account-card-list.component.html',
  styleUrls: ['./account-card-list.component.scss']
})
export class AccountCardListComponent implements OnInit {
  @Input() accounts: AccountCard[];

  constructor() { }

  ngOnInit() {
  }

}
