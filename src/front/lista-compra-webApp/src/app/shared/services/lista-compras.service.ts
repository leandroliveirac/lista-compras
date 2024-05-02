import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Itens } from '../../features/itens-compra/interfaces/itens';
import { API } from '../../core/models/API';

@Injectable({
  providedIn: 'root'
})
export class ListaComprasService {

  results!: Itens[];

  constructor(private httpClient: HttpClient) { }


  obterItensCompra()
  {
    return this.httpClient.get<Itens[]>(API.ITENS_COMPRAS)    
  }
}
