import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { CatmashApiService } from '../../shared/api/catmash-api.service';
import { Cat } from '../../shared/models/cat.model';

@Component({
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.less']
})
export class VoteComponent implements OnInit, OnDestroy {

  private _subscription: Subscription;
  public cats: Cat[] = [];
  public leftCat?: Cat = undefined;
  public rightCat?: Cat = undefined;

  constructor(
    private _apiService: CatmashApiService
  ) { 
    this._subscription = new Subscription();
  }

  ngOnInit(): void {
    this._subscription.add( 
      this._apiService.getAllCats().subscribe(cats => {
        this.cats = cats;
        this.setRandomCats();
      })
    );
  }

  getRandomCat(): Cat | undefined {
    if( this.cats.length === 0 ) return undefined;
    return this.cats[Math.floor(Math.random() * this.cats.length)];
  }

  setRandomCats(): void {
    this.leftCat = this.getRandomCat();
    this.rightCat = this.getRandomCat();

    while( this.rightCat!.id === this.leftCat!.id ){
      this.rightCat = this.getRandomCat();
    }
  }

  ngOnDestroy(): void {
    this._subscription.unsubscribe();
  }
}
