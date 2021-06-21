import { Routes } from '@angular/router';
import { AccountControlPageComponent } from './account-control-page/account-control-page.component';
import { CostControlPageComponent } from './cost-control-page/cost-control-page.component';
import { IncomeControlPageComponent } from './income-control-page/income-control-page.component';
import { LoginComponent } from './login/login.component';

export const appRoutes : Routes = [
    {
        path: '',
        redirectTo: '/accounts',
        pathMatch: 'full'
    },
    {
        path: 'auth',
        component: LoginComponent
    },
    {
        path: 'accounts',
        component: AccountControlPageComponent
    },
    {
        path: 'costs',
        component: CostControlPageComponent
    },
    {
        path: 'incomes',
        component: IncomeControlPageComponent
    }
]