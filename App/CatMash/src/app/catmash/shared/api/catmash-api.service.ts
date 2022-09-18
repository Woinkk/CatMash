import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Cat } from '../models/cat.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CatmashApiService {
  private baseUrl: string = `${environment.apiBase}/api/cat`;
  
  constructor(
    private httpClient: HttpClient,
  ) { }

  public getAllCats(): Observable<Cat[]> {
    return this.httpClient.get<Cat[]>( `${this.baseUrl}/getAllCats` );
  }

  public updateCatScore(id: string): Observable<any> {
    const options = {
    };
    return this.httpClient.put( `${this.baseUrl}/vote?id=${id}`, options);
  }
}
