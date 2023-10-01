import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http:HttpClient) { }

  register(userCredentials:any){
    //this.http.post("https://pro401-2.azurewebsites.net/api/account/register", userCredentials).subscribe({
    this.http.post("https://localhost:7107/api/account/register", userCredentials).subscribe({
      next: resp => {
        console.log(resp);
      },
      error: err => {
        console.log(err);
      } 
    });
  }
}
