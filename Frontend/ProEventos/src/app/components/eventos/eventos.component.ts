import { Evento } from 'src/app/models/Evento';
import { EventoService } from './../../services/evento.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
  providers: [EventoService],
})
export class EventosComponent implements OnInit {
  public eventos: Evento[] = [];
  public eventosFilter: Evento[] = [];
  public widthImg: number = 100;
  public marginImg: number = 2;
  public displayImg: boolean = true;
  private _filterList: string = '';

  public get filterList(): string {
    return this._filterList;
  }

  public set filterList(value: string) {
    this._filterList = value;
    this.eventosFilter = this.filterList
      ? this.filtrarEventos(this.filterList)
      : this.eventos;
  }

  public filtrarEventos(filterPor: string): Evento[] {
    filterPor = filterPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: { tema: string; local: string }) =>
        evento.tema.toLocaleLowerCase().indexOf(filterPor) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filterPor) !== -1
    );
  }

  constructor(private eventoService: EventoService) {}

  ngOnInit(): void {
    this.gerEventos();
  }

  public alterarImagem(): void {
    this.displayImg = !this.displayImg;
  }

  public gerEventos(): void {
    this.eventoService.getEventos().subscribe({
      next: (_eventos: Evento[]) => {
        this.eventos = _eventos;
        this.eventosFilter = this.eventos;
      },
      error: (error: any) => console.log(error),
    });
  }
}
