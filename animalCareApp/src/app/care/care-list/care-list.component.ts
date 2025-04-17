import { Component, OnInit } from '@angular/core';
import { CareService } from '../../core/services/care.service';
import { AnimalService } from '../../core/services/animal.service';
import { Router } from '@angular/router';
import { Care } from '../../core/models/care.model';
import { Animal } from '../../core/models/animal.model';

@Component({
  selector: 'app-care-list',
  templateUrl: './care-list.component.html',
  styleUrls: ['./care-list.component.css'],
  standalone: false
})
export class CareListComponent implements OnInit {
  cares: Care[] = [];
  animals: Animal[] = [];
  loading: boolean = true;
  showAlert: boolean = false;

  constructor(
    private careService: CareService,
    private animalService: AnimalService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadCares();
    this.loadAnimals();
  }

  loadCares(): void {
    this.careService.getAllCares().subscribe({
      next: (data) => {
        this.cares = data;
        this.loading = false;

        setTimeout(()=> {
          if(this.cares.length === 0){
            this.showAlert = true;
          }
        },500)
      },
      error: (err) => {
        console.error('Erro ao carregar cuidados', err);
      }
    });
  }

  loadAnimals(): void {
    this.animalService.getAllAnimals().subscribe({
      next: (data) => {
        this.animals = data;
      },
      error: (err) => {
        console.error('Erro ao carregar animais', err);
      }
    });
  }

  getAnimalNames(animalCares: { animalId: string }[]): string {
    const ids = animalCares?.map(ac => ac.animalId) || [];
    const names = this.animals
      .filter(animal => ids.includes(animal.id))
      .map(animal => animal.name);
    return names.join(', ');
  }

  goToCreate(): void {
    this.router.navigate(['/care/new']);
  }

  editCare(id: string): void {
    this.router.navigate(['/care/edit', id]);
  }

  deleteCare(id: string): void {
    if (confirm('Tem certeza que deseja excluir este cuidado?')) {
      this.careService.deleteCare(id).subscribe({
        next: (response) => {
          if (response) {
            this.loadCares();
          } else {
            console.error('Erro: Não foi possível excluir o cuidado');
          }
        },
        error: (err) => {
          console.error('Erro ao excluir cuidado', err);
          console.log('Resposta completa do erro:', err);
        }
      });
    }
  }
}
