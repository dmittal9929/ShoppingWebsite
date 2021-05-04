import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { editDTO } from '../dataClasses/editDTO';
import { ApiService } from '../service/api.service';

@Component({
  selector: 'app-adminupdate',
  templateUrl: './adminupdate.component.html',
  styleUrls: ['./adminupdate.component.css']
})
export class AdminupdateComponent implements OnInit {


  id:string
  edit:any

  constructor(private route:ActivatedRoute,private ser:ApiService,private rt:Router) {
    
    this.route.params.subscribe((param)=>{
      this.id=param.id
    })

    this.ser.getProductById(this.id).subscribe(e=>{
      console.log(e);
      this.edit=e;
    })

    console.log(this.edit)
   }

  ngOnInit(): void {
  }

  onSubmitadd(data:any){

    this.ser.editProduct(this.id,data).subscribe(e=>{
      console.log(e);   
      alert("Done")
      this.rt.navigateByUrl('/admin')

    })
  }

}
