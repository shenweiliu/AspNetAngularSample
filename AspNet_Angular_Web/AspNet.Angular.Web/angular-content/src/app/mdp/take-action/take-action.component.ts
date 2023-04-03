import { Component, OnInit } from '@angular/core';
import { MessageService } from '../../shared/services/message.service';

@Component({
    moduleId: module.id,
    selector: 'take-action',
    templateUrl: './take-action.component.html',
    styleUrls: ['./take-action.component.css']
})
export class TakeActionComponent implements OnInit {    
    parentModel: any = {};

    constructor(private messageService: MessageService) {
    }  

    ngOnInit() {
        this.parentModel = history.state;
        if (!this.parentModel.companyId && window.sessionStorage.getItem('parentModel') != null) {
            this.parentModel = JSON.parse(window.sessionStorage.getItem('parentModel'));
        }
    }
}
