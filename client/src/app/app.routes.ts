import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { InstrumentListComponent } from './instruments/instrument-list/instrument-list.component';
import { InstrumentDetailComponent } from './instruments/instrument-detail/instrument-detail.component';
import { authGuard } from './_guards/auth.guard';

export const routes: Routes = [
    {path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [authGuard],
        children: [
            {path: 'members', component: MemberListComponent},
            {path: 'member/:id', component: MemberDetailComponent},
            {path: 'instruments', component: InstrumentListComponent},
            {path: 'instruments/:id', component: InstrumentDetailComponent}
        ]
    },
    {path: '**', component: HomeComponent, pathMatch: 'full'}
];
