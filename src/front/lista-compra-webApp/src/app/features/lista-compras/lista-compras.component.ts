import { DialogData } from './../../shared/components/Dialog/Interfaces/DialogData';
import { Component } from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatButtonModule} from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { DialogComponent } from '../../shared/components/Dialog/Dialog.component';
import { MatDialog } from '@angular/material/dialog';
import {MatListModule} from '@angular/material/list';
import { ListaCompras } from './interfaces/ListaCompras';
import { ListaComprasService } from '../../shared/services/lista-compras.service';
import { map, take } from 'rxjs';
import { CommonModule } from '@angular/common';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner'
import { RouterModule } from '@angular/router';
import { ItensCompraComponent } from "../itens-compra/itens-compra.component";

@Component({
    selector: 'app-lista-compras',
    standalone: true,
    templateUrl: './lista-compras.component.html',
    styleUrls: ['./lista-compras.component.css'],
    imports: [
        MatIconModule,
        MatButtonModule,
        MatFormFieldModule,
        MatInputModule,
        FormsModule, MatListModule,
        CommonModule,
        MatProgressSpinnerModule,
        RouterModule,
        ItensCompraComponent
    ]
})
export class ListaComprasComponent{

  constructor(public dialog: MatDialog, private listaComprasService: ListaComprasService) { }

  exibirItens : boolean = false;
  idLista: number = 0;

  listas$ = this.obterListas();

  private obterListas() {
    return this.listaComprasService.obterListas()
    .pipe(
      map( resp => {
        return resp
      }),
      take(1)
    );
  }

  openDialog() : void
  {
    const dialogRef = this.dialog.open(DialogComponent, {
      data: {titulo : "Nova Lista", nome : ''}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
    });
  }

  mostrarItens(event: Event)
  {
    const el = event.target as HTMLElement;

    const div = el.closest('div');

    const input = div?.querySelector('input[name="idLista"]') as HTMLInputElement

    const valor = parseInt(input?.value ?? '0');

     isNaN(valor) ? 0 : valor;

    if(isNaN(valor)) return;

    this.idLista = valor;

    this.exibirItens = true;
  }

  ocultarItens()
  {
    this.exibirItens = false;
  }

}
