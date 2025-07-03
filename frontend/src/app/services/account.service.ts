import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {User} from '../models/user';
import {Router} from '@angular/router';
import {environment} from "../../environments/environment";
import {Observable, tap} from 'rxjs';
import {jwtDecode} from 'jwt-decode';
@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private currentUser: User | null = null;
  user: any;
  isloggedin: boolean = false;
  private baseUrl = `${environment.apiUrl}/Identity/User`;
  constructor(private http: HttpClient, private router: Router) {
    /*   this.currentUser = JSON.parse(localStorage.getItem("currentUser") || 'null');*/
  }

  register(user: {name: string, email: string, userName: string,
    address: string, city: string, state: string, zipCode: string,
    dateOfBirth: Date, password: string, confirmPassword: string}): Observable<any> {
    return this.http.post(`${this.baseUrl}/register`, user);
  }

  login(credentials: { email: string; password: string, rememberMe: boolean }): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/login`, credentials).pipe(
      tap((res: any) => {
        this.saveToken(res.token);
        localStorage.setItem("token", res.token);
        this.isloggedin = true;
      })
    );
  }
  logout() {
    this.clearToken();
    this.isloggedin = false;
    this.router.navigate(['/account']);

  }

  saveToken(token: string): void {
    localStorage.setItem('token', token);
  }

  // Remove the token (e.g., after logout)
  clearToken(): void {
    localStorage.removeItem('token');
  }


  // Retrieve the token
  getToken(): string | null {
    return localStorage.getItem('token');
  }
  getDecodedToken(): any {
    const token = this.getToken();
    if(!token) {
      return null;
    }
    return jwtDecode(token);
  }
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl);
  }

  getUserById(id: string): Observable<User> {
    return this.http.get<User>(`${this.baseUrl}/${id}`);
  }

  updateUserById(id: string, user: FormData): Observable<any> {
    return this.http.put(`${this.baseUrl}/${id}`, user);
  }

  deleteUser(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
  /*  getUserImageUrl(relativePath: string): Observable<{ imageUrl: string }> {
      return this.http.get<{ imageUrl: string }>(
        `${this.baseUrl}/get-users-image`,
        { params: { relativePath } }
      );
    }*/
  getUserImageUrl(relativePath: string): Observable<{ imageUrl: string }> {
    return this.http.get<{ imageUrl: string }>(
      `${this.baseUrl}/get-user-image-path`,
      { params: { relativePath } }
    );
  }
  getCurrentUser(): User | null {
    return this.currentUser;
  }
  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }
  setCurrentUser(user: User): void {
    this.currentUser = user;
    localStorage.setItem('currentUser', JSON.stringify(user));
  }

  getUserBySearch(query: string){
    return this.http.get<User[]>(`${this.baseUrl}/search?query=${query}`);
  }
}
