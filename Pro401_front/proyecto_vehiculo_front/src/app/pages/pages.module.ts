import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { IonicModule } from '@ionic/angular';
import { RegisterComponent } from './register/register.component';
import { MenuComponent } from './menu/menu.component';
import { ListQuestionnaireComponent } from './list-questionnaire/list-questionnaire.component';
import { QrComponent } from './qr/qr.component';
import { ConfigureComponent } from './configure/configure.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    MenuComponent,
    ListQuestionnaireComponent,
    QrComponent,
    ConfigureComponent
  ],
  imports: [
    IonicModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class PagesModule { }
