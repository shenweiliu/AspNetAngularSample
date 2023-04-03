import { Component } from '@angular/core';

//For bypass route checking and error rendering.
@Component({
    selector: 'route-catch-all',
    template: `<div></div>`
    //templateUrl: './route-catch-all.component.html' //not working.    
})
export class RouteCatchAllComponent {
    constructor() { }

    //May handle 404 in this component...
}
