import { Component, OnInit, Renderer2, ElementRef } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { filter, switchMap } from 'rxjs/operators';
import { MessageService } from '../shared/services/message.service';
import * as mdpGlob from './settings/globals';

@Component({
    moduleId: module.id.toString(),
    selector: 'mdp-main',
    templateUrl: './mdp-main.component.html',
    styleUrls: ['./mdp-main.component.css']
})
export class MdpMainComponent implements OnInit {
    parentModel: any = {};    
    routerId: number = 10;
    
    //Set defaults.
    homeTabLabel: string = 'My Home';
    
    constructor(private renderer: Renderer2, private elementRef: ElementRef, 
        private activatedRoute: ActivatedRoute, private router: Router, private messageService: MessageService) {
    }        

    ngOnInit() {  
        if (window.sessionStorage.getItem('parentModel') == null) {
            let _serverParams = this.elementRef.nativeElement.getAttribute('serverParams');
            this.parentModel = JSON.parse(_serverParams);           
        }
        else {
            this.parentModel = JSON.parse(window.sessionStorage.getItem('parentModel'));
        }
        mdpGlob.SetConfigWithCompanyInfo(this.parentModel.companyId);
        this.parentModel.companyPathMain = mdpGlob.MdpConfig.companyPathMain;
        this.parentModel.webApiRootUrl = mdpGlob.MdpConfig.webApiRootUrl;
        window.sessionStorage.setItem('parentModel', JSON.stringify(this.parentModel));        

        let pThis: any = this;
        this.router.events.pipe(filter(value => value instanceof NavigationEnd)).subscribe((value: any) => {            
            let rootRoute: ActivatedRoute = pThis.activatedRoute.root;
            //...
        });
    }

    ngOnDestroy() {
    }
        
    openDialog(id: any) {
        window.alert('Module Project Main: Test debugging after page load.');
    };
}
