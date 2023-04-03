import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MessageService } from '../../shared/services/message.service';

@Component({
    moduleId: module.id,
    selector: 'contacts',
    templateUrl: './contacts.component.html',
    styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit {    
    parentModel: any = {};

    constructor(private route: ActivatedRoute, private router: Router, private messageService: MessageService) {
    }  

    ngOnInit() {
        this.parentModel = history.state;
        if (!this.parentModel.companyId && window.sessionStorage.getItem('parentModel') != null) {
            this.parentModel = JSON.parse(window.sessionStorage.getItem('parentModel'));
        }               
    }
}
