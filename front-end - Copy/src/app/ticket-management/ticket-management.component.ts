import { Component, OnInit } from '@angular/core';
import { TableModule } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DropdownModule } from 'primeng/dropdown';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CalendarModule } from 'primeng/calendar';
import { InputTextModule } from 'primeng/inputtext';
import { FloatLabelModule } from 'primeng/floatlabel';

@Component({
  selector: 'app-ticket-management',
  templateUrl: './ticket-management.component.html',
  styleUrls: ['./ticket-management.component.scss'],
  standalone: true,
  imports: [
    TableModule,
    DialogModule,
    ButtonModule,
    DropdownModule,
    CommonModule,
    FormsModule,
    FormsModule,
    ReactiveFormsModule,
    ToastModule,
    CalendarModule,
    InputTextModule,
    FloatLabelModule,
  ],
})
export class TicketManagementComponent implements OnInit {
  tickets: Ticket[] = [];
  ticket: Ticket = { ticketId: 0, description: '', status: 'Open', date: new Date() };
  displayDialog: boolean = false;
  isEdit: boolean = false;

  statusOptions = [
    { label: 'Open', value: 0 },
    { label: 'Closed', value: 1 },
  ];

  constructor(
    private ticketService: TicketService,
    public messageService: MessageService
  ) {}

  ngOnInit() {
    this.loadTickets();
  }

  loadTickets() {
    this.ticketService.getTickets().subscribe({
      next: (data) => {
        this.tickets = data;
        this.messageService.add({
          severity: 'success',
          summary: 'Success',
          detail: 'Data loaded successfully',
        });
      },
      error: (err) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'Failed to load data',
        });
      },
    });
  }
  showDialogToAdd() {
    this.isEdit = false;
    this.ticket = { ticketId: 0, description: '', status: 'Open', date: new Date};
    this.displayDialog = true;
  }

  editTicket(ticket: Ticket) {
    this.isEdit = true;
    this.ticket = { ...ticket,date: new Date(ticket.date)};
    this.displayDialog = true;
  }

  saveTicket() {
    if (this.isEdit) {
      this.ticketService.updateTicket(this.ticket).subscribe({
        next: () => {
          this.loadTickets();
          this.messageService.add({
            severity: 'success',
            summary: 'Success',
            detail: 'Ticket updated successfully',
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Failed to update ticket',
          });
        },
      });
    } else {
      this.ticketService.createTicket(this.ticket).subscribe({
        next: () => {
          this.loadTickets();
          this.messageService.add({
            severity: 'success',
            summary: 'Success',
            detail: 'Ticket created successfully',
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Failed to create ticket',
          });
        },
      });
    }
    this.displayDialog = false;
  }
  getStatusLabel(statusValue: number): string {
    const status = this.statusOptions.find(
      (option) => option.value === statusValue
    );
    return status ? status.label : 'Unknown';
  }
  deleteTicket(id: number) {
    this.ticketService.deleteTicket(id).subscribe({
      next: () => {
        this.loadTickets();
        this.messageService.add({
          severity: 'warn',
          summary: 'Deleted',
          detail: 'Ticket deleted successfully',
        });
      },
      error: () => {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'Failed to delete ticket',
        });
      },
    });
  }

  hideDialog() {
    this.displayDialog = false;
  }
}

@Injectable({
  providedIn: 'root',
})
export class TicketService {
  private apiUrl = 'http://localhost:7171/api/Tickets'; // Your  API URL :)

  constructor(private http: HttpClient) {}

  getTickets(): Observable<Ticket[]> {
    return this.http.get<Ticket[]>(this.apiUrl);
  }

  createTicket(ticket: Ticket): Observable<Ticket> {
    return this.http.post<Ticket>(this.apiUrl, ticket);
  }

  updateTicket(ticket: Ticket): Observable<any> {
    return this.http.put(`${this.apiUrl}/${ticket.ticketId}`, ticket);
  }

  deleteTicket(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}

export interface Ticket {
  ticketId: number;
  description: string;
  status: string;
  date: Date;
}
