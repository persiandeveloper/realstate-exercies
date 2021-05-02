import { Component } from '@angular/core';
import { RealstateService } from 'src/api/generated/controllers/Realstate';
import { RealStateObject } from 'src/api/generated/model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'angular-app';
  topAgents: RealStateObject[];
  topDeals: RealStateObject[];

  constructor(private dataService: RealstateService){
  }

  public ngOnInit() {
    // 7. the returned observable is fully typed
    this.dataService
      .topAgents()
      // 8. returned data are fully typed
      .subscribe(data => {
        // 9. assignments are type-checked
        this.topAgents = data;
      });

    this.dataService
      .topDeals()
      // 8. returned data are fully typed
      .subscribe(data => {
        // 9. assignments are type-checked
        this.topDeals = data;
      });
  }
}
