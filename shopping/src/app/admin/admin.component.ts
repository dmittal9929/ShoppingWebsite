import { Component, OnInit } from '@angular/core';
import { ApiService } from '../service/api.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  prods:any
  
  constructor(private ser:ApiService) { 
    this.ser.getallProduct().subscribe(e=>{
      console.log(e);
      this.prods=e;
    })
  }

  ngOnInit(): void {
  }

}
