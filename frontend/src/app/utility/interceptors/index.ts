import {AuthInterceptor} from "./auth.interceptor";


export const interceptors: any[] = [
  AuthInterceptor,
];

export * from './auth.interceptor';
