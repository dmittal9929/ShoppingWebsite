import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ProductComponent } from './product/product.component';
import { ProductdetailComponent } from './productdetail/productdetail.component';
import { TestComponent } from './test/test.component';
import {ShopcartComponent} from './shopcart/shopcart.component'
import { Admin3Component } from './admin3/admin3.component';
import { AdminupdateComponent } from './adminupdate/adminupdate.component';
import { AdminComponent } from './admin/admin.component';
import { AdminloginComponent } from './adminlogin/adminlogin.component';
import { AuthGuard } from './auth.guard';


const routes: Routes = [
  {path:'home',component:HomeComponent},
  {path:'product',component:ProductComponent},
  {path:'product/:gender',component:ProductComponent},
  {path:'login', component:LoginComponent},
  {path:'detail/:pid',component:ProductdetailComponent},
  {path:'test',component:TestComponent},
  {path:'cart',component:ShopcartComponent},
  {path:'nav',component:NavbarComponent},
  {path:'footer',component:FooterComponent},
  {path:'admin',component:AdminComponent, canActivate:[AuthGuard]},
  {path:'add',component:Admin3Component, canActivate:[AuthGuard]},
  {path:'edit/:id',component:AdminupdateComponent, canActivate:[AuthGuard]},
  {path:'adminlogin',component:AdminloginComponent},
  {path:'',redirectTo:'/home',pathMatch:'prefix'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
