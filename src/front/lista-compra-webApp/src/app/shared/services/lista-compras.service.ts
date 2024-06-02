import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Itens } from '../../features/itens-compra/interfaces/itens';
import { API } from '../../core/models/API';
import { ListaCompras } from '../../features/lista-compras/interfaces/ListaCompras';

@Injectable({
  providedIn: 'root'
})
export class ListaComprasService {

  results!: Itens[];

  constructor(private httpClient: HttpClient) { }


  obterItensLista(idLista: number)
  {
    return this.httpClient.get<Itens[]>(API.LISTA_COMPRAS + `/${idLista}/listar-itens`)
  }


  obterListas()
  {
    return this.httpClient.get<ListaCompras[]>(API.LISTA_COMPRAS)
  }
}
