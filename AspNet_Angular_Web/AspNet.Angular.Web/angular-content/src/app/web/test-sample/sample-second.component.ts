import { Component } from '@angular/core';

@Component({
    moduleId: module.id.toString(),
    selector: 'sample-second',
    templateUrl: './sample-second.component.html'
})
export class SampleSecondComponent {
    
    constructor() { }
    
    openSimpleInfo() {    
        window.alert("Sample Second Test");
    }    
}
