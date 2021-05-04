import { Component, OnInit } from '@angular/core';
import { ApiService } from '../service/api.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {

  prods:any
  constructor(private ser:ApiService) { 

    this.ser.getallProduct()
  }


  ngOnInit(): void {
  }

}
