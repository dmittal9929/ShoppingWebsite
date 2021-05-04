import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { loginDTO } from '../dataClasses/loginDTO';
import { ApiService } from '../service/api.service';

@Component({
  selector: 'app-adminlogin',
  templateUrl: './adminlogin.component.html',
  styleUrls: ['./adminlogin.component.css']
})
export class AdminloginComponent implements OnInit {

  login:loginDTO = new loginDTO();

  constructor(private api:ApiService,private snackbar:MatSnackBar,private route:Router) { }

  ngOnInit(): void {
  }

 
    OnLogin(){
      this.api.adminLogin(this.login).subscribe(async res=>{
        console.log(res);
        sessionStorage.setItem("user",res["uid"]) ;
        await this.snackbar.open(": :Login Successful",'',{
          verticalPosition:'top',
          horizontalPosition:'right',
          'panelClass':'green'
        })
        

        setTimeout(()=>{this.route.navigateByUrl("/admin")
        this.snackbar.dismiss()},2000)
        
      },err=>{
        this.snackbar.open(": :Login Unsuccessful",'',{
          verticalPosition:'top',
          horizontalPosition:'right',
          'panelClass':'red'
        })
        

        setTimeout(()=>{this.snackbar.dismiss()},1500)
        
      },()=>{
        console.log("done");
      })
   }

  }

