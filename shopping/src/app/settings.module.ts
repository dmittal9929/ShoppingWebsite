import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { AdminComponent } from "./admin/admin.component";
 
    import { RouterModule } from "@angular/router";

@NgModule({
  imports: [CommonModule, RouterModule],
  declarations: [AdminComponent ]
})
export class SettingsModule {}