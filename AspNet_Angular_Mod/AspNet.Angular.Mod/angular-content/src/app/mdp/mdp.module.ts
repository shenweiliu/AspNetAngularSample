///<reference path="../../../node_modules/@types/node/index.d.ts" />

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MdpRoutingModule } from './mdp-routing.module';
import { HomeTabComponent } from './home-tab/home-tab.component';
import { ContactsComponent } from './contacts/contacts.component';
import { TakeActionComponent } from './take-action/take-action.component';

@NgModule({
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        MdpRoutingModule //Last item.
    ],
    declarations: [
        HomeTabComponent,
        ContactsComponent,
        TakeActionComponent
    ],
    providers: [        
    ],
    entryComponents: [        
    ]
})
export class MdpModule {}
