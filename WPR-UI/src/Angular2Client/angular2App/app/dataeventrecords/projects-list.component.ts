import { Component, OnInit } from '@angular/core';
import { SecurityService } from '../services/SecurityService';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';

import { DataEventRecordsService } from '../dataeventrecords/DataEventRecordsService';
import { Project } from './models/Project';

@Component({
    selector: 'project-list',
    templateUrl: 'projects-list.component.html'
})

export class ProjectsListComponent implements OnInit {

    public message: string;
    public Projects: Project[];

    constructor(
        private _dataEventRecordsService: DataEventRecordsService,
        public securityService: SecurityService,
        private _router: Router) {
        this.message = 'DataEventRecords';
    }

    ngOnInit() {
        this.getData();
    }


    private getData() {
        console.log('DataEventRecordsListComponent:getData starting...');
        this._dataEventRecordsService
            .GetAll()
            .subscribe(data => this.Projects = data,
            error => this.securityService.HandleError(error),
            () => console.log('Get all completed'));
    }

}
