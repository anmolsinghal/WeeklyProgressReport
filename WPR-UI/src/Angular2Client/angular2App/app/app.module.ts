import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { Configuration } from './app.constants';
import { routing } from './app.routes';
import { HttpModule, JsonpModule } from '@angular/http';

import { SecurityService } from './services/SecurityService';
import { LoginComponent } from './login/login.component';
import { DataEventRecordsService } from './dataeventrecords/DataEventRecordsService';

import { ForbiddenComponent } from './forbidden/forbidden.component';
import { HomeComponent } from './home/home.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';

import { ProjectsListComponent } from './dataeventrecords/projects-list.component';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        routing,
        HttpModule,
        JsonpModule
    ],
    declarations: [
        AppComponent,
        LoginComponent,
        ForbiddenComponent,
        HomeComponent,
        UnauthorizedComponent,
        ProjectsListComponent
    ],
    providers: [
        SecurityService,
        DataEventRecordsService,
        Configuration
    ],
    bootstrap: [AppComponent],
})

export class AppModule { }