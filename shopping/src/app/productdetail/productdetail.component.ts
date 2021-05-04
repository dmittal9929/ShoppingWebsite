import { Component, ElementRef, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../service/api.service';

@Component({
  selector: 'app-productdetail',
  templateUrl: './productdetail.component.html',
  styleUrls: ['./productdetail.component.css']
})
export class ProductdetailComponent implements OnInit {
  prod;
  qty:number=1;
  image:string
  id:any;
  visibilty=true;
  constructor(private route:ActivatedRoute,private ser:ApiService,private eleRef:ElementRef) { 
    this.route.params.subscribe((param)=>{
      this.id=param.pid
      console.log(this.id)
    })
    this.ser.getProductById(this.id).subscribe((res)=>{
      this.prod=res;
      this.image =this.prod.image 
      console.log(this.prod)
    })
  }
  ngOnInit(): void {
    
  }


  AddToCart(){
    this.visibilty=false;
    const items = (() => {
      const fieldValue = localStorage.getItem('cart');
      return fieldValue === null
        ? []
        : JSON.parse(fieldValue);
    })();
    
    // 3.
    items.push({"PID":this.prod.pid,"price":this.prod.price,"quantity":this.qty});
    
    // 4.
    localStorage.setItem('cart', JSON.stringify(items));
    
  }
  RemoveFromCart(){
    this.visibilty=true;
    let items = (() => {
      const fieldValue = localStorage.getItem('cart');
      return fieldValue === null
        ? []
        : JSON.parse(fieldValue);
    })();
    let res =[]
    for(let item of items){
      if(item.PID!=this.prod.pid){
        res.push(item)
      }
    }

    localStorage.setItem('cart', JSON.stringify(res));
  }



  increase(){
    if(this.qty<5){
      this.qty++;
    }
    
  }
  decrease(){
    if(this.qty>1){
      this.qty--;
    }
  }

}
