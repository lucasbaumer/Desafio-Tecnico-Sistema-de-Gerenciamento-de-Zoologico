import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Animal } from '../models/animal.model';
import { environment } from '../../../Environment/Environment';

@Injectable({
  providedIn: 'root'
})
export class AnimalService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}


  getAllAnimals(): Observable<Animal[]> {
    return this.http.get<Animal[]>(`${this.apiUrl}/animal`).pipe(
      catchError(this.handleError)
    );
  }


  getAnimalById(id: string): Observable<Animal> {
    return this.http.get<Animal>(`${this.apiUrl}/animal/${id}`).pipe(
      catchError(this.handleError)
    );
  }


  createAnimal(animal: Animal): Observable<Animal> {
    return this.http.post<Animal>((`${this.apiUrl}/animal`), animal).pipe(
      catchError(this.handleError)
    );
  }

  updateAnimal(id: string, animal: Animal): Observable<any> {
    return this.http.put(`${this.apiUrl}/animal/${id}`, animal, {
      responseType: 'text'
    });
  }

  deleteAnimal(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/animal/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = `Erro: ${error.error.message}`;
    } else {
      errorMessage = `Código de status: ${error.status}\nMensagem: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
