import { Routes, RouterModule } from '@angular/router';
import { ProjectsListComponent } from './projects-list.component';

export const Projects_ROUTES: Routes = [
    {
        path: 'projects',

        children: [
            { path: '', redirectTo: 'list', pathMatch: 'full' },
            //{
            //    path: 'create',
            //    component: DataEventRecordsCreateComponent
            //},
            //{
            //    path: 'edit/:id',
            //    component: DataEventRecordsEditComponent
            //},
            {
                path: 'list',
                component: ProjectsListComponent,
            }
        ]
    }
];