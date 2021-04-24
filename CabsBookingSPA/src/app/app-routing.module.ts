import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CabTypesComponent } from './cab-types/cab-types.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {path: "", component: HomeComponent},
  {path: "CabTypes/:id", component: CabTypesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
