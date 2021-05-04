import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../service/api.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  prods :any;
  gender:string="";
  search:string="";
  constructor(private route:ActivatedRoute,private ser:ApiService) { 
    this.route.paramMap.subscribe(params => {
      this.ngOnInit();
  });
    

  }

  ngOnInit(): void {
    this.getdata()
  }
  getdata(){
    this.route.params.subscribe((param)=>{
      this.gender=param.gender
      
    })
    this.route.queryParams.subscribe((params)=>{
      this.search=params.search
      
    })
    if(this.gender==undefined){
      this.gender=""
    }
    if(this.search==undefined){
      this.search=""
    }

    this.ser.getProduct(this.gender,this.search).subscribe((prod)=>{
      console.log(prod);
      this.prods=prod;
    })
  }
}
