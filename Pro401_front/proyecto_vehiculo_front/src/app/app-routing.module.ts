import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { MenuComponent } from './pages/menu/menu.component';
import { UserGuard } from './guards/user.guard';
import { ListQuestionnaireComponent } from './pages/list-questionnaire/list-questionnaire.component';
import { QrComponent } from './pages/qr/qr.component';
import { ConfigureComponent } from './pages/configure/configure.component';
import { RecoverPasswordComponent } from './pages/recover-password/recover-password.component';

const routes: Routes = [
  {
    path:'',
    component: LoginComponent
  },
  {
    path: 'registro',
    component: RegisterComponent
  },
  {
    path: 'home',
    loadChildren: () => import('./pages/tabs/tabs.module').then(m => m.TabsPageModule),
    canLoad :[UserGuard]
  },
  {
    path: 'menu',
    component: MenuComponent
  },
  {
    path: 'list-questionnarie',
    component: ListQuestionnaireComponent
  },
  {
    path: 'qr',
    component: QrComponent
  },
  {
    path: 'Configure',
    component: ConfigureComponent
  },
  {
    path: 'recover-password',
    component: RecoverPasswordComponent 
  }

];
@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
