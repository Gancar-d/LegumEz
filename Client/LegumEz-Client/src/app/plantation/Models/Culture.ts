import { UUID } from "crypto";

export type Culture = {
    id : UUID, 
    nom : string, 
    conditionCroissance : ConditionCroissance,
    conditionGermination : ConditionGermination
}

export type ConditionCroissance = {
    temperatureMinimale : Temperature,
    temperatureOptimale : Temperature,
    tempsDeCroissance : Temps
}

export type ConditionGermination = {
    temperatureMinimale : Temperature,
    temperatureOptimale : Temperature,
    tempsDeGermination : Temps
}

export type Temperature = {
    valeur : number,
    unite : UniteTemperature
}

export type Temps = {
    valeure : number,
    unite : UniteTemps
}

export enum UniteTemperature
{
    Celsius = 0,
    Fahrenheit
}

export enum UniteTemps {
    Jours = 0,
    Semaines,
    Mois
}
