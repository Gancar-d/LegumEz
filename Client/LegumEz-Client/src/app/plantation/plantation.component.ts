import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { PlantationService } from './Services/PlantationService';
import { Culture } from './Models/Culture';
import { SearchboxComponent } from '../../searchbox/searchbox.component';

@Component({
  selector: 'app-plantation',
  standalone: true,
  imports: [SearchboxComponent, FormsModule],
  templateUrl: './plantation.component.html',
  styleUrl: './plantation.component.css'
})
export class PlantationComponent 
{
  private possibleCultures : Culture[] = [];

  constructor(private plantationService: PlantationService) {
  }

  ngOnInit() {
    this.plantationService.getAllPossibleCultures()
      .subscribe(data => 
        {
          this.possibleCultures = data;
          this.cultureSuggestions = this.possibleCultures.map(culture => culture.nom);
        });
  }

  cultureSuggestions : string[] = []
  localisation : string = '';
  selectedCultureName: string = '';

  getCultureInformations() {
    alert(this.selectedCultureName + " | " + this.localisation);
  }
}
