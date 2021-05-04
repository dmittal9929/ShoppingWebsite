import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private route:Router){}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree 

    {
      console.log('authgaurd');
    if(sessionStorage.getItem('user'))
      return true;
    else
     {
       alert("Admin Authentication Required. Please Login")
       this.route.navigate(['/adminlogin'])
      return false;
     }

    }
  
}