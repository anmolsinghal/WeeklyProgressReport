import { Routes, RouterModule } from '@angular/router';

import { ForbiddenComponent } from './forbidden/forbidden.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';

import { Projects_ROUTES } from './dataeventrecords/projects.routes';

const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'login', component: LoginComponent },
    { path: 'home', component: HomeComponent },
    { path: 'Forbidden', component: ForbiddenComponent },
    { path: 'Unauthorized', component: UnauthorizedComponent },
    ...Projects_ROUTES,
];

export const routing = RouterModule.forRoot(appRoutes);
