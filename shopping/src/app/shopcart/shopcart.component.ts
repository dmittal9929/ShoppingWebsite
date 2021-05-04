import { Component, OnInit,Inject } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { ApiService } from '../service/api.service';
import {MatDialog,MatDialogConfig} from '@angular/material/dialog'
import { OrderDialogComponent } from '../notifications/order-dialog/order-dialog.component';


@Component({
  selector: 'app-shopcart',
  templateUrl: './shopcart.component.html',
  styleUrls: ['./shopcart.component.css']
})
export class ShopcartComponent implements OnInit {
  prods:any
  disp:any=[]
  count:number=0

  grandTotal:number=0;
  constructor(private ser:ApiService,private router:Router,
    private snackbar:MatSnackBar,
    private dialog:MatDialog) {
    

   }

  ngOnInit(): void {
    this.prods= JSON.parse(localStorage.getItem('cart'))
    this.prods.forEach(element => {
      this.grandTotal+= parseInt(element.quantity)*parseInt(element.price)
      this.count++;
      this.ser.getProductById(element.PID).subscribe((res)=>{
        this.disp.push({
            ...res,
            "quantity":element.quantity,
            "total": parseInt(element.quantity)*parseInt(element.price)
        })
        
      })
    });
    console.log(this.count)
  }
  OnChange(id,quantity){
    this.grandTotal=0;
    for(let p of this.prods){
      
      if(p.PID==id){
        p.quantity=quantity
      }
      
      
    }
    for(let d of this.disp){
      
      if(d.pid==id){
        d.total= parseInt(d.price)*parseInt(d.quantity);
        
      }
      this.grandTotal+=d.total;
    }
    console.log(this.disp);
    localStorage.setItem('cart',JSON.stringify(this.prods))
  }
  RemoveFromCart(id){
    let items = (() => {
      const fieldValue = localStorage.getItem('cart');
      return fieldValue === null
        ? []
        : JSON.parse(fieldValue);
    })();
    let res =[]
    for(let item of this.prods){
      if(item.PID!=id){
        res.push(item)
      }
    }
    localStorage.setItem('cart', JSON.stringify(res));
    console.log(this.router.url);
    let currentUrl = this.router.url
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
      this.router.navigate([currentUrl]);
      console.log(currentUrl);
  });
  }
  Order(){
     let user = localStorage.getItem('user');
     
     if(user==null){
      this.snackbar.open("::Please Login First",'',{
       duration:1500,
        verticalPosition:'top',
        horizontalPosition:'right',
        'panelClass':'Red'
      })
      this.router.navigateByUrl("/login")
     }
     else{
      this.dialog.open(OrderDialogComponent)
     }
    
  //   this.ser.placeOrder(user,data).subscribe((res)=>{
      
  //   },err=>{
  //     console.log(err);
  //   })
  
  } 
  shopping(){
    this.router.navigateByUrl("/product")
  }

}
