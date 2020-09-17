import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Registration } from '../Models/registration.models';

@Injectable({
  providedIn: 'root'
})
export class TestapiService {

  constructor(private http:HttpClient) { }

  Getall(){
    return this.http.get('https://jsonplaceholder.typicode.com/posts')
  }

    postregistration(registration:Registration){
      alert(registration.Username)
      return this.http.post('https://localhost:44333/api/registrations/', registration)
    }
}
