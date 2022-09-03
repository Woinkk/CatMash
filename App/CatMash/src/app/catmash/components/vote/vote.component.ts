import { Component, OnInit } from '@angular/core';
import { CatmashApiService } from '../../shared/api/catmash-api.service';

@Component({
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.less']
})
export class VoteComponent implements OnInit {

  constructor(
    private _apiService: CatmashApiService
  ) { }

  ngOnInit(): void {
    console.log(this._apiService.getCatList());
  }

}
