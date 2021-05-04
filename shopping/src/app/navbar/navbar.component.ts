import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  search:string;
  constructor(private router:Router,private snackbar:MatSnackBar) { }

  ngOnInit(): void {
  }
  onSearch(){
    this.router.navigateByUrl('/home').then(()=>{
      this.router.navigate(['/product'],{queryParams:{search:this.search}})
    })
    
    console.log(this.search)
  }
  async Logout(){
    localStorage.removeItem('user')
    
    
    await this.snackbar.open(": :Logged Successfully  ",'',{
      verticalPosition:'top',
      horizontalPosition:'right',
      'panelClass':'green'
    })
    

    setTimeout(()=>{this.router.navigateByUrl("")
    this.snackbar.dismiss()},1500)
    
  }
}
