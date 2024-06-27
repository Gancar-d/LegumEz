import { Routes } from '@angular/router';
import { MeteoComponent } from './meteo/meteo.component';
import { PlantationComponent } from './plantation/plantation.component';

export const routes: Routes = [
    {
        path: 'meteo',
        component: MeteoComponent,
    },
    {
        path: 'plantation',
        component : PlantationComponent
    }
];
