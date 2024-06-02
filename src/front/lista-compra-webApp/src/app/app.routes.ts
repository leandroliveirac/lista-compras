import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { ItensCompraComponent } from './features/itens-compra/itens-compra.component';
import { ListaComprasComponent } from './features/lista-compras/lista-compras.component';

export const routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'lista', component: ListaComprasComponent },
    { path: 'itens-lista', component: ItensCompraComponent },
    { path: '', redirectTo: 'home', pathMatch: 'full'},
    { path: '**', redirectTo: 'home', pathMatch: 'full'},
];
