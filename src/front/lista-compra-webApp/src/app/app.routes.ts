import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { ItensCompraComponent } from './features/itens-compra/itens-compra.component';

export const routes: Routes = [
    {
        path: 'home', component: HomeComponent
    },
    {
        path: 'lista', component: ItensCompraComponent
    }
];
