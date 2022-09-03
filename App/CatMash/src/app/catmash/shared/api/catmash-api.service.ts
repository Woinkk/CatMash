import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Cat } from '../models/cat.model';

@Injectable({
  providedIn: 'root'
})
export class CatmashApiService {
  private baseUrl: string = "http://localhost:5000/api/cat";
  
  constructor(
    private httpClient: HttpClient,
  ) { }

  public getCatList(): Observable<Cat[]> {
    return this.httpClient.get<Cat[]>( `${this.baseUrl}/getCatList` );
  }
}
