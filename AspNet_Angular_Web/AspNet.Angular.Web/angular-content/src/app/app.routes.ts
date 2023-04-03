import { Component } from '@angular/core';
import { Routes } from '@angular/router';
import { WebMainComponent } from './web/web-main.component';
import { RouteCatchAllComponent } from './web/route-catch-all/route-catch-all.component';

export const routes: Routes = [
    { path: '', redirectTo: '', pathMatch: 'full' },    
    { path: 'web-main', component: WebMainComponent },
    { path: '**', component: RouteCatchAllComponent }
];

