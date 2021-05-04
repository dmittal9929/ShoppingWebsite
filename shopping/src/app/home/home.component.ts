import { Component, OnInit } from '@angular/core';
import { MatCarousel, MatCarouselComponent } from '@ngbmodule/material-carousel';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  
  constructor() { }

  ngOnInit(): void {
  }
  slides = [
    {'image': 'https://forever21.imgix.net/img/app/shopmedia/production/1/16-66-6821.jpg?w=1349&auto=format'}, 
  {'image': 'https://forever21.imgix.net/img/app/shopmedia/production/1/16-66-6825.jpg?w=1349&auto=format'},
    {'image': 'https://img.freepik.com/free-vector/fashion-background-with-shirt-sunglasses-pants-shoes_83728-1890.jpg?size=626&ext=jpg'}, 
  {'image': 'https://storage.sg.content-cdn.io/in-resources/22a79ec5-e694-4d7a-ac5a-85c8fa45b7f1/Images/userimages/summer-shirts-new-m.jpg'},
  
   {'image': 'https://sslimages.shoppersstop.com/sys-master/root/h09/hd7/16593746362398/Gini-%26-Jony--WEB-01.jpg'}];
  }