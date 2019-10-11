import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Client } from './models/Client';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  private _baseUrl: string;
  public clients: Client[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this._baseUrl = baseUrl;
  }

  getClients(): Observable<Client[]> {
    return this.http.get<Client[]>(this._baseUrl + 'api/Clients')
      .pipe(tap(), catchError(this.handleError<Client[]>('getClients', [])));
  }

  getClient(id: string): Observable<Client> {
    const url = this._baseUrl + '/api/clients/details/' + id;
    return this.http.get<Client>(url).pipe(
      tap(_ => ({})),
      catchError(this.handleError<Client>('getClient id=${id}'))
    );
  }

  createClient(client: any): Observable<Client> {
    return this.http.post<Client>(this._baseUrl + 'api/clients/create', client)
      .pipe(tap(), catchError(this.handleError<Client>('createClient')));
  }

  updateClient(client: Client): Observable<any> {
    return this.http.post<Client>(this._baseUrl + 'api/clients/update/' + client.id, client)
      .pipe(tap(_ => { }), catchError(this.handleError<Client>('updateClient')));
  }

  /**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
