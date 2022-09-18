import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CatmashApiService } from '../../shared/api/catmash-api.service';
import { Cat } from '../../shared/models/cat.model';

@Component({
  selector: 'app-cat-card',
  templateUrl: './cat-card.component.html',
  styleUrls: ['./cat-card.component.less']
})
export class CatCardComponent implements OnInit {

  @Input()
  cat?: Cat;

  @Output() voteEvent: EventEmitter<void> = new EventEmitter<void>();

  constructor(
    private _apiService: CatmashApiService
  ) { }

  ngOnInit(): void {
    
  }

  async vote(id: string): Promise<void> {
    await this._apiService.updateCatScore(id).toPromise();
    this.voteEvent.emit();
  }

}
