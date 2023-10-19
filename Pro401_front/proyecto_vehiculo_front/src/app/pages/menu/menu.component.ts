import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
})
export class MenuComponent  implements OnInit {

  constructor(
    private router:Router,
  ) { }

  ngOnInit() {}

  tolistQuestionarie(){
    console.log("tolist-questionnarie");
    this.router.navigate(['/list-questionnarie']);
  }
  toQr(){
    console.log("toQr");
    this.router.navigate(['/qr']);
  }
  toConfigure(){
    console.log("toConfigure");
    this.router.navigate(['/Configure']);
  }
}
