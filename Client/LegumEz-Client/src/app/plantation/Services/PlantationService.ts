import { Injectable, inject } from "@angular/core";
import { Culture } from "../Models/Culture";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root',
  })
export class PlantationService
{
    private httpClient = inject(HttpClient);

    getAllPossibleCultures() : Observable<Culture[]>
    {
        return this.httpClient.get<Culture[]>("/api/culture");
    }
}

