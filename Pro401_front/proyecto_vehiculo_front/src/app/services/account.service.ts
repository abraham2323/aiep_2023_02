import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

const URL = environment.API_URL;

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http:HttpClient, private router:Router) { }

  register(userCredentials:any){
    console.log(URL);
    this.http.post(`${URL}/api/Account/register`, userCredentials).subscribe({
      next: resp => {
        console.log(resp);
      },
      error: err => {
        console.log(err);
      }
    });
  }

  loginUser(userCredentials:any){
    return this.http.post(`${URL}/api/Account/login`, userCredentials);
  }

  checkToken(){
    let token = localStorage.getItem('token');
    if(!token){
      this.router.navigate(['/']);
      return;
    }

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });

    this.http.get(`${URL}/api/Account/user`,{headers}).subscribe({
      next: resp => {
        if(!resp){
          this.router.navigate(['/']);
        }
      },
      error: err => {
        this.router.navigate(['/']);
      }
    });
  }

}
 