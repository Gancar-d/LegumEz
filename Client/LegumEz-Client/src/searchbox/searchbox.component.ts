import { Component, Input, Output, EventEmitter, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Subject, debounceTime, distinctUntilChanged } from 'rxjs';

@Component({
  selector: 'app-searchbox',
  templateUrl: './searchbox.component.html',
  styleUrls: ['./searchbox.component.css'],
  imports: [FormsModule],
  standalone: true
})
export class SearchboxComponent 
{
  private querySubject: Subject<string> = new Subject<string>();
  
  @Input() allSuggestions: string[] = [];
  @Input() placeHolder: string = 'Rechercher ...';
  
  @Output() queryChangedEvent = new EventEmitter<string>();
  
  query: string = '';
  suggestions: string[] = [];

  ngOnInit() 
  {
    this.querySubject.pipe(
      debounceTime(200),
      distinctUntilChanged()
    ).subscribe(_ => this.onQueryChanged());
  }

  updateQuery()
  {
    this.querySubject.next(this.query);
  }

  onQueryChanged()
  {
    this.suggestions = this.allSuggestions.filter(s => s.toLowerCase().includes(this.query.toLowerCase()));
    this.queryChangedEvent.emit(this.query);
  }

  selectSuggestion(suggestion: string)
  {
    this.query = suggestion;
    this.onQueryChanged();

    this.suggestions = [];
  }
}
