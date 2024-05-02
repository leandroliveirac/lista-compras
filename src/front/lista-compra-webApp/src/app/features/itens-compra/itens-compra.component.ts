import { Component, Renderer2, ViewChild } from '@angular/core';
import {MatTable, MatTableDataSource,MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatCardModule} from '@angular/material/card';
import { RouterModule } from '@angular/router';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { Itens } from './interfaces/itens';
import { ListaComprasService } from '../../shared/services/lista-compras.service';
import { Observable, map, take, tap } from 'rxjs';
import { CommonModule } from '@angular/common';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';

@Component({
  selector: 'app-itens-compra',
  standalone: true,
  imports: [
    MatFormFieldModule, 
    MatInputModule, 
    MatTableModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    RouterModule,
    CommonModule,
    MatProgressSpinnerModule,
  ],
  templateUrl: './itens-compra.component.html',
  styleUrl: './itens-compra.component.scss'
})
export class ItensCompraComponent {

  constructor(private renderer: Renderer2, private listaComprasService: ListaComprasService) {}

  private source : Itens[] = [];

  total: number = 0;  

  displayedColumns: string[] = ['categoria', 'produto', 'quantidade', 'valorUnitario', 'subTotal','acoes'];

  dataSource  = new MatTableDataSource<Itens>(); 
  
  dataSource$ : Observable<MatTableDataSource<Itens>> = this.listaComprasService.obterItensCompra()
    .pipe (
      map( resp => {
        this.source = resp;
        const dataSource = this.dataSource;        
        dataSource.data = this.source;
        return dataSource;
      }),
      take(1)
    );

  @ViewChild(MatTable)
  table!: MatTable<Itens>;

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  limparDados(event: Event) {
    const el = event.target as HTMLElement;

    const tableRow = el.closest('tr');
    const itemId = this.obterItemId(tableRow);

    this.AtualizarObjSource(itemId, 0, 0, 0);

    this.alterarValorInputQuantidade(tableRow);
    this.alterarValorInputValorUnitario(tableRow);
    this.alterarValorElementSubTotal(tableRow,0);
  }

  atualizarSubTotal(event: Event)
  {
    const el = event.target as HTMLInputElement;

    const tableRow = el.closest('tr');

    const itemId = this.obterItemId(tableRow);    

    const quant = this.obterValorInputQuantidade(tableRow);

    const valorUnitario = this.obterValorInputValorUnitario(tableRow);

    const subTotal: number = valorUnitario * quant;

    this.alterarValorElementSubTotal(tableRow,subTotal);

    this.AtualizarObjSource(itemId, quant, valorUnitario, subTotal);

  }
  
  private alterarValorElementSubTotal(tableRow: HTMLTableRowElement | null, valor: number = 0) : void
  {
    if(tableRow === null) return;

    const tdSubtotal = tableRow?.querySelectorAll('td')[4];

    this.renderer.setProperty(tdSubtotal,'innerText',`R$ ${valor.toFixed(2)}`);
  }

  private AtualizarObjSource(itemId: number, quant: number, valorUnitario: number, subTotal: number) {
    
    this.source.map((obj) => {
      if (parseInt(obj.id) == itemId) {
        obj.quantidade = quant;
        obj.valorUnitario = valorUnitario,
          obj.subTotal = subTotal;
      }      
    });
    
    this.CalcularTotal();
  }

  private obterValorInputQuantidade(tableRow: HTMLTableRowElement | null) : number
  {
    if(tableRow === null) return 0;

    const input = tableRow?.querySelectorAll('td')[2].querySelector('input') as HTMLInputElement;

    const valor = parseInt(input?.value ?? '0');

    return isNaN(valor) ? 0 : valor;
  }

  private alterarValorInputQuantidade(tableRow: HTMLTableRowElement | null, valor: number = 0) : void
  {
    if(tableRow === null) return;

    const input = tableRow?.querySelectorAll('td')[2].querySelector('input') as HTMLInputElement;

    this.renderer.setProperty(input,'value',valor);
  }

  private obterValorInputValorUnitario(tableRow: HTMLTableRowElement | null) : number
  {
    if(tableRow === null) return 0;

    const input = tableRow?.querySelectorAll('td')[3].querySelector('input') as HTMLInputElement;

    const valor = parseFloat(input?.value ?? '0');
    
    return isNaN(valor) ? 0 : valor;
  }

  private alterarValorInputValorUnitario(tableRow: HTMLTableRowElement | null, valor: number = 0) : void
  {
    if(tableRow === null) return;

    const input = tableRow?.querySelectorAll('td')[3].querySelector('input') as HTMLInputElement;

    this.renderer.setProperty(input,'value',valor.toFixed(2));
  }

  private obterItemId(tableRow: HTMLTableRowElement | null) : number
  {
    if(tableRow === null) return 0;

    const itemId = tableRow.querySelector('input#itemId') as HTMLInputElement;

    return parseInt(itemId?.value ?? '0');
  }

  private CalcularTotal()
  {
    this.total = 0;

    this.source.forEach((obj) => {
      this.total += isNaN(obj.subTotal) ? 0 : obj.subTotal
    });
  }
}
