import { NgModule } from '@angular/core';
import {RouterModule, Routes} from "@angular/router";
import * as fromUsers from "./components/users";
import {authGuard} from './utility/guards/auth.guard';

export const routes: Routes = [
  {path: '', children: [
      {path: '', component: fromUsers.LoginComponent},
      {path:'register', component: fromUsers.RegisterComponent},
      {path: '**', redirectTo: ''}
    ]},
  {path: 'users', canActivate: [authGuard],  children: [
    {path: '', component: fromUsers.UserListComponent},
      {path: 'profile/:id', component: fromUsers.UserDetailComponent},
      {path: 'create', component: fromUsers.UserCreateComponent},
      {path: 'update/:id', component: fromUsers.UserUpdateComponent},
      {path: '**', redirectTo: ''}
    ]}
];



@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
