import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CabTypesService } from '../core/services/cab-types.service';
import { CabTypes } from '../shared/model/cab-types';

@Component({
  selector: 'app-cab-types',
  templateUrl: './cab-types.component.html',
  styleUrls: ['./cab-types.component.css']
})
export class CabTypesComponent implements OnInit {

  cabtypes: CabTypes | undefined;
  id!: number;
  
  constructor(private cabTypeService: CabTypesService, private router : Router, private route : ActivatedRoute) { }

  ngOnInit(){
    this.route.paramMap.subscribe(
      params=>{
        this.id = +params.getAll('id');
        this.cabTypeService.getCabTypesWithBookings(this.id).subscribe(
          c=>{
            this.cabtypes = c;
            console.table(this.cabtypes)
          }
        )
      }
    )
  }
}
