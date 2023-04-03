import { Component, ElementRef, OnInit, Renderer2 } from '@angular/core';

@Component({
    moduleId: module.id,
    selector: 'web-main',
    templateUrl: "./web-main.component.html"
    //styleUrls: ["./web-main.component.css"]
})
export class WebMainComponent implements OnInit {
    serverParams!: any;
    showText: string = '';
    constructor(private renderer: Renderer2, private elementRef: ElementRef) {
    }

    ngOnInit() {
        this.serverParams = this.elementRef.nativeElement.getAttribute('serverParams');

        this.showText = 'Text rendered from Web Main - ' + 'Parameter: ' + this.serverParams;
    }

    openSimpleInfo() {
        window.alert("Web Main Post-load Test");
    }
    
}
