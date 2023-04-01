import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeTabComponent } from './home-tab/home-tab.component';
import { ContactsComponent } from './contacts/contacts.component';
import { TakeActionComponent } from './take-action/take-action.component';
import { MdpConfig } from './settings/globals';

const jaxcRoutes: Routes = [
    {
        path: MdpConfig.companyRouteMain + '/home-tab', component: HomeTabComponent
    },
    {
        path: MdpConfig.companyRouteMain + '/contacts', component: ContactsComponent

    },   
    {
        path: MdpConfig.companyRouteMain + '/take-action', component: TakeActionComponent
    },    
    //Default to home-tab.
    {   
        path: MdpConfig.companyRouteMain, redirectTo: MdpConfig.companyRouteMain + '/home-tab', pathMatch: 'full'
    }
]; 

@NgModule({
    imports: [
        RouterModule.forChild(jaxcRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class MdpRoutingModule { }
