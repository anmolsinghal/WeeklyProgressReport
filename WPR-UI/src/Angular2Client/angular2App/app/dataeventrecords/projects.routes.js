import { ProjectsListComponent } from './projects-list.component';
export var Projects_ROUTES = [
    {
        path: 'projects',
        children: [
            { path: '', redirectTo: 'list', pathMatch: 'full' },
            {
                path: 'list',
                component: ProjectsListComponent,
            }
        ]
    }
];
//# sourceMappingURL=projects.routes.js.map