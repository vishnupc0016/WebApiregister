import { Component, OnInit } from '@angular/core';
import { TestapiService } from '../services/testapi.service';
import {NgForm} from '@angular/forms';
import { Registration } from '../Models/registration.models';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor( private regservice: TestapiService) { }

  ngOnInit(): void {
  }
  onSubmits(frm:NgForm){
    alert(frm.value.name);
var registration=new Registration();
registration.Username=frm.value.username;
registration.Email=frm.value.Email;
registration.Phn=frm.value.phn;

this.regservice.postregistration(registration).subscribe(
      
  err => { console.log(err); }
);

}
}