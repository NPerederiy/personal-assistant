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
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader} from '@ngx-translate/http-loader';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';

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
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    TranslateModule.forRoot({
      loader: {
          provide: TranslateLoader,
          useFactory: HttpLoaderFactory,
          deps: [HttpClient]
      }
  })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

// required for AOT compilation
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}