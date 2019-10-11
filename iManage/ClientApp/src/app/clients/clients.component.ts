import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { error } from 'util';
import { ClientService } from '../client.service';
import { Client } from '../models/client';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements OnInit {

  success: boolean;
  error: string;
  clients: Client[];

  constructor(private clientService: ClientService) { }

  getClients(): void {
    this.clientService.getClients().subscribe(clients => this.clients = clients);
  }

  onSubmit(name: string, phone: string, occupation: string) {
    name = name.trim();
    phone = phone.trim();
    occupation = occupation.trim();

    this.clientService.createClient({ name, phone, occupation } as Client)
      .pipe(finalize(() => { }))
      .subscribe(result => {
        if (result) {
          this.success = true;
          this.getClients();
        }
      }, error => { this.error = error; });
  }

  ngOnInit(): void {
    this.getClients();
  }

}
