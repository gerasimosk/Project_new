import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { HomeComponent } from "./home/home.component";
import { MapComponent } from "./map/map.component";
import { UserDetailsComponent } from './users/user-details/user-details.component';
import { UsersComponent } from "./users/users.component";

const appRoutes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'users', component: UsersComponent },
    { path: 'users/:id', component: UserDetailsComponent },
    { path: 'users/new', component: UserDetailsComponent },
    { path: 'map', component: MapComponent }
]

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule {

}