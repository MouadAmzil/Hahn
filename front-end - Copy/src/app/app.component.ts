import { Component } from '@angular/core';
import { TicketManagementComponent, TicketService } from './ticket-management/ticket-management.component';
import { HttpClientModule } from '@angular/common/http';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-root',
  template: `
    <div class="container">
    <app-ticket-management></app-ticket-management>
    </div>
  `,
  standalone: true,
  imports: [TicketManagementComponent],  
  providers: [TicketService,HttpClientModule,MessageService]
})
export class AppComponent {}
