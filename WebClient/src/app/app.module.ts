import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountControlPageComponent } from './account-control-page/account-control-page.component';
import { AccountCardListComponent } from './account-control-page/account-card-list/account-card-list.component';
import { AccountCardComponent } from './account-control-page/account-card-list/account-card/account-card.component';
import { BankCardComponent } from './account-control-page/account-card-list/account-card/bank-card/bank-card.component';
import { BankAccountComponent } from './account-control-page/account-card-list/account-card/bank-account/bank-account.component';
import { PiggyBankComponent } from './account-control-page/account-card-list/account-card/piggy-bank/piggy-bank.component';
import { CashComponent } from './account-control-page/account-card-list/account-card/cash/cash.component';
import { MainMenuComponent } from './main-menu/main-menu.component';
import { MainMenuButtonComponent } from './main-menu/main-menu-button/main-menu-button.component';
import { IncomeControlPageComponent } from './income-control-page/income-control-page.component';
import { CostControlPageComponent } from './cost-control-page/cost-control-page.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './app.routes';

@NgModule({
  declarations: [
    AppComponent,
    AccountControlPageComponent,
    AccountCardListComponent,
    AccountCardComponent,
    BankCardComponent,
    BankAccountComponent,
    PiggyBankComponent,
    CashComponent,
    MainMenuComponent,
    MainMenuButtonComponent,
    IncomeControlPageComponent,
    CostControlPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
