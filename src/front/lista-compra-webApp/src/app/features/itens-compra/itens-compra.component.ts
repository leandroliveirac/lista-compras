import { Component, ViewChild } from '@angular/core';
import {MatTable, MatTableDataSource,MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatCardModule} from '@angular/material/card';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';


import { Itens } from './interfaces/itens';

const source: Itens[] = [
  {_id:'1',categoria:'Bebidas',nomeProduto:'suco de uva',quantidade:1,valorUnitario:2,total:2},
  {_id:'2',categoria:'Higiene',nomeProduto:'sabonete',quantidade:1,valorUnitario:1,total:1},
  {_id:'3',categoria:'Frutas e legumes',nomeProduto:'Abacaxi',quantidade:2,valorUnitario:2,total:4}
];

@Component({
  selector: 'app-itens-compra',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatTableModule,MatCardModule,MatToolbarModule,MatIconModule],
  templateUrl: './itens-compra.component.html',
  styleUrl: './itens-compra.component.scss'
})
export class ItensCompraComponent {

  displayedColumns: string[] = ['categoria', 'nomeProduto', 'quantidade', 'valorUnitario', 'total','deleteEmployee'];
  dataSource  = new MatTableDataSource(source);

  @ViewChild(MatTable)
  table!: MatTable<Itens>;

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource .filter = filterValue.trim().toLowerCase();
  }

  removeData(event: Event) {
    const el = event.target;
    console.log(el);
    // this.dataSource.pop();
    this.table.renderRows();
  }
}
