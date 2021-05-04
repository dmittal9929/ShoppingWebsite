import { Component, ElementRef, OnInit,Input } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../service/api.service';

@Component({
  selector: 'app-productcard',
  templateUrl: './productcard.component.html',
  styleUrls: ['./productcard.component.css']
})
export class ProductcardComponent implements OnInit {
  @Input () prod:any;
  constructor(private elementRef:ElementRef,private ser:ApiService,private route:Router) { 
      }

  ngOnInit(): void {
  }
  showDetails(data){
    this.route.navigateByUrl('/detail/'+data)
  }
  AddToCart(){
    const items = (() => {
      const fieldValue = localStorage.getItem('cart');
      return fieldValue === null
        ? []
        : JSON.parse(fieldValue);
    })();
    
    // 3.
    items.push({"PID":this.prod.pid,"price":this.prod.price,"quantity":1});
    
    // 4.
    localStorage.setItem('cart', JSON.stringify(items));
    console.log("inside");
    var d1 = this.elementRef.nativeElement.querySelector('.bottom');
    d1.classList.add("clicked")
  }
  RemoveFromCart(){
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
    console.log(res);
    localStorage.setItem('cart', JSON.stringify(res));
    var d1 = this.elementRef.nativeElement.querySelector('.bottom');
    d1.classList.remove("clicked")
  }
  
}
