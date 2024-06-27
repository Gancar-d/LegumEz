import { Component } from '@angular/core';
import { PlantationService } from './Services/PlantationService';
import { Culture } from './Models/Culture';

@Component({
  selector: 'app-plantation',
  standalone: true,
  imports: [],
  templateUrl: './plantation.component.html',
  styleUrl: './plantation.component.css'
})
export class PlantationComponent {
  constructor(private plantationService: PlantationService) {
  }

  ngOnInit() {
    this.plantationService.getAllPossibleCultures()
      .subscribe(data => 
        {
          this.possibleCultures = data;
        });
  }

  public possibleCultures : Culture[] = [];
}
