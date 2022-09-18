import { Component, OnInit } from '@angular/core';
import { Observable, timer } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { CatmashApiService } from '../../shared/api/catmash-api.service';
import { Cat } from '../../shared/models/cat.model';

@Component({
  templateUrl: './leaderboard.component.html',
  styleUrls: ['./leaderboard.component.less']
})
export class LeaderboardComponent implements OnInit {
  
  public cats$: Observable<Cat[]>;

  constructor(
    private _apiService: CatmashApiService
  ) { 
    const timer$ = timer(0, 10000);
    this.cats$ = timer$.pipe(
      switchMap(x => this._apiService.getAllCats())
      );
  }

  ngOnInit() {

  }
}
