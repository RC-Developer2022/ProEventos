import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {
  public eventos: any = [];
  widthImg: number = 100;
  marginImg: number = 2;
  displayImg: boolean = true;
  filterList: string = '';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.gerEventos();
  }

  alterarImagem() {
    this.displayImg = !this.displayImg;
  }

  public gerEventos(): void {
    this.http.get('http://localhost:5247/api/eventos').subscribe(
      (response) => (this.eventos = response),
      (error) => console.log(error)
    );
  }
}
