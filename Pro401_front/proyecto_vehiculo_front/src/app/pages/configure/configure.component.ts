import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-configure',
  templateUrl: './configure.component.html',
  styleUrls: ['./configure.component.scss'],
})
export class ConfigureComponent  implements OnInit {

  brillo: number = 50;

  actualizarBrillo() {
    // Aquí puedes realizar acciones relacionadas con el brillo, como ajustar la pantalla.
    console.log('Brillo actualizado:', this.brillo);
  }

  ngOnInit() {}

}
