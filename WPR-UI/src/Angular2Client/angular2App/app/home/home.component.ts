import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'home',
    templateUrl: 'home.component.html'
})

export class HomeComponent implements OnInit {

    public message: string;
    public values: any[];

    constructor(private router: Router) {
        router.navigate(['/login']);
    }

    ngOnInit() {
    }
}
