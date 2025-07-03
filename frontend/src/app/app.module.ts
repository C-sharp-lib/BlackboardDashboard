import { NgModule } from '@angular/core';
import {AppComponent} from './app.component';
import * as fromUsers from './components/users/index';
import * as fromServices from './services/index';
import * as fromInterceptors from './utility/interceptors/index';
import * as fromPipes from './utility/pipes/index';

import {ReactiveFormsModule} from "@angular/forms";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {ToastrModule} from "ngx-toastr";
import {QuillModule} from "ngx-quill";
import {AppRoutingModule} from "./app-routing.module";
import {BrowserModule} from '@angular/platform-browser';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
    ...fromUsers.components,
    ...fromPipes.pipes,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-top-center',
      preventDuplicates: false,
      progressBar: true,
      progressAnimation: 'increasing',
      closeButton: true,
      iconClasses: {
        error: 'toast-error',
        success: 'toast-success',
        info: 'toast-info',
        warning: 'toast-warning',
      }
    }),
    QuillModule.forRoot()
  ],
  providers: [
    ...fromServices.services,
    ...fromInterceptors.interceptors,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: fromInterceptors.AuthInterceptor,
      multi: true,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
