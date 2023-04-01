import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from '../../shared/services/message.service';

@Component({
    moduleId: module.id,
    selector: 'home-tab',
    templateUrl: './home-tab.component.html',
    styleUrls: ['./home-tab.component.css']
})
export class HomeTabComponent implements OnInit {    
    parentModel!: any;

    constructor(private router: Router, private activatedRoute: ActivatedRoute,
                private messageService: MessageService ) {
        //this.parentModel = this.router.getCurrentNavigation().extras.state
    }  

    ngOnInit() {
        this.parentModel = history.state;
        if (!this.parentModel.companyId && window.sessionStorage.getItem('parentModel') != null) {
            this.parentModel = JSON.parse(window.sessionStorage.getItem('parentModel'));
        }
    }    
    
       
}
