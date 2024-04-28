import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItensCompraComponent } from './itens-compra.component';

describe('ItensCompraComponent', () => {
  let component: ItensCompraComponent;
  let fixture: ComponentFixture<ItensCompraComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ItensCompraComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ItensCompraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
