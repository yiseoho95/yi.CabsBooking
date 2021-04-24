import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CabTypesService } from '../core/services/cab-types.service';
import { CabTypes } from '../shared/model/cab-types';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  cabtypes: CabTypes[] | undefined;
  constructor(private cabTypeService: CabTypesService, private router : Router, private route : ActivatedRoute) { }

  ngOnInit(){
    this.cabTypeService.getAllCabTypes().subscribe(
      c=>{
        this.cabtypes = c;
        console.table(this.cabtypes);
      }
    )
  }

}
