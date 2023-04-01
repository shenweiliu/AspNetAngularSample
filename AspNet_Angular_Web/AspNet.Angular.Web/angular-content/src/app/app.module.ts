import { NgModule, Inject, Type, ApplicationRef, DoBootstrap, ComponentFactoryResolver, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { CommonModule, DOCUMENT, APP_BASE_HREF } from "@angular/common";
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { WebModule } from "./web/web.module";
import { MdpModule } from './mdp/mdp.module';
//import { JaxcModule } from './jaxc/jaxc.module';

import { WebMainComponent } from './web/web-main.component';
import { MdpMainComponent } from './mdp/mdp-main.component';
//import { JaxcMainComponent } from './jaxc/jaxc-main.component';

import { RouteCatchAllComponent } from './web/route-catch-all/route-catch-all.component';
import { routes } from './app.routes';

import { MessageService } from './shared/services/message.service'

@NgModule({
    imports: [
        CommonModule,
        BrowserModule,
        FormsModule,
        RouterModule.forRoot(routes),                
        HttpClientModule,        
        WebModule,
        MdpModule
        //JaxcModule
    ],
    declarations: [
        WebMainComponent,        
        MdpMainComponent,        
        RouteCatchAllComponent
    ],
    providers: [
        [MessageService],
        { provide: APP_BASE_HREF, useValue: '/' }
    ],    
    entryComponents: [
        WebMainComponent,
        MdpMainComponent
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
    //schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA]
    //,bootstrap: [AppComponent]
})

export class AppModule implements DoBootstrap {
    static bootstrapComponents: Type<{}>[] = [
        WebMainComponent,
        MdpMainComponent
        //JaxcMainComponent
    ];

    constructor(
        @Inject(DOCUMENT) private _document: any,
        private _componentFactoryResolver: ComponentFactoryResolver
    ) { }

    ngDoBootstrap(applicationRef: ApplicationRef) {
        for (const component of AppModule.bootstrapComponents) {
            const { selector } = this._componentFactoryResolver.resolveComponentFactory(component);

            if (this._document.querySelector(selector)) {
                applicationRef.bootstrap(component);
            }
        }
    }
}

