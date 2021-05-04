import { Component, ElementRef, OnInit, Renderer2 } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { loginDTO } from '../dataClasses/loginDTO';
import { signUpDTO } from '../dataClasses/signupDTO';
import { ApiService } from '../service/api.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  login:loginDTO = new loginDTO();
  signup:signUpDTO = new signUpDTO();
 
  constructor(private renderer:  Renderer2,private elementRef: ElementRef,private api:ApiService,
    private route:Router,private snackbar:MatSnackBar
    ) {

   }
 
   OnLogin(){
      this.api.login(this.login).subscribe(async res=>{
        console.log(res);
        localStorage.setItem("user",res["uid"]) ;
        await this.snackbar.open(": :Login Successful",'',{
          verticalPosition:'top',
          horizontalPosition:'right',
          'panelClass':'green'
        })
        

        setTimeout(()=>{this.route.navigateByUrl("")
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

  OnSignUp(){
    this.signup.dob+= "T17:16:40"
    this.api.signup(this.signup).subscribe(async res=>{
      this.snackbar.open("::SignUp Successful",'',{
        verticalPosition:'top',
        horizontalPosition:'right',
        'panelClass':'green'
      })
      

      await setTimeout(()=>{this.snackbar.dismiss()},1500)
      
      this.login.email=this.signup.email
      this.login.password=this.signup.password
      this.logOn(this.login)
      
    },async err=>{
      this.snackbar.open("::"+err.error,'',{
        verticalPosition:'top',
        horizontalPosition:'right',
        'panelClass':'red'
      })
      

      await setTimeout(()=>{this.snackbar.dismiss()},2000)
      console.log()
    },()=>{
      console.log("done");
    })
  }
  logOn(data){
    this.api.login(this.login).subscribe(res=>{
      localStorage.setItem("user",res["uid"]) ;
      this.route.navigateByUrl("")
    },err=>{
      alert("Login Failed");
    },()=>{
      console.log("done");
    })

  }
  OpenSignUp(){
    
    var d1 = this.elementRef.nativeElement.querySelector('.container');
    d1.classList.add("right-panel-active")
  }
  OpenSignIn(){
    var d1 = this.elementRef.nativeElement.querySelector('.container');
    d1.classList.remove("right-panel-active")
  }
  ngOnInit(): void {
  }

}



  