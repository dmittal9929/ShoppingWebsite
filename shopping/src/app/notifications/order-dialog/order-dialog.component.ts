import { Component, OnInit,Inject } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/service/api.service';


@Component({
  selector: 'app-order-dialog',
  templateUrl: './order-dialog.component.html',
  styleUrls: ['./order-dialog.component.css']
})
export class OrderDialogComponent implements OnInit {
  address:string;
  constructor(private ser:ApiService,private snackbar:MatSnackBar,
    private router:Router){

  }
  
  ngOnInit(): void {
  }
  PlaceOrder(){
    let user = localStorage.getItem('user')
    console.log("order")
    console.log(user);
    let data = {
      "daddress":this.address,
      "CartItems":JSON.parse(localStorage.getItem('cart'))
    }
      this.ser.placeOrder(user,data).subscribe((res)=>{
        this.snackbar.open("::Order PLaced SuccessFully",'',{
          verticalPosition:'top',
          horizontalPosition:'right',
          'panelClass':'green'
        })
        localStorage.removeItem('cart')
        setTimeout(() => {
          let currentUrl = this.router.url
  this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
    this.router.navigate([currentUrl]);
    console.log(currentUrl);
  });          
  this.snackbar.dismiss()
        }, 1000);
    },err=>{
      this.snackbar.open("::Order Not PLaced ",'',{
        verticalPosition:'top',
        horizontalPosition:'right',
        'panelClass':'red'
      })
      console.log(err);
    })
  }
  

}
