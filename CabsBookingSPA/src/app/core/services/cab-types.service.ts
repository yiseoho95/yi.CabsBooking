import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CabTypes } from 'src/app/shared/model/cab-types';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class CabTypesService {

  constructor(private apiService : ApiService) { }

  getAllCabTypes():Observable<CabTypes[]>{
    return this.apiService.getAll('CabTypes');
  }

  getCabTypesWithBookings(id:number):Observable<CabTypes>{
    return this.apiService.getById(`${'CabTypes'}`,id);
  }
}
