import { HttpClientModule } from '@angular/common/http';
import { TestBed, async } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { Observable, of } from 'rxjs';
import { RealstateService } from 'src/api/generated/controllers/Realstate';
import { RealStateObject } from 'src/api/generated/model';
import { AppComponent } from './app.component';
import { TestHelper } from './test.helper';

class StubRealstateService {
  topAgents(): Observable<RealStateObject[]>{
    return of(JSON.parse("[]"));
  };
  topDeals(): Observable<RealStateObject[]>{
    return of(JSON.parse("[]"));
  };
}

let injectedService : StubRealstateService;

describe('AppComponent', () => {
  let stubRealstateService = new StubRealstateService();

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppComponent
      ],
      imports: [
        HttpClientModule,
      ],
      providers: [{ provide: RealstateService, useValue: stubRealstateService }]
    }).compileComponents();
    
    injectedService = TestBed.get(RealstateService);

  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'angular-app'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('angular-app');
  });

  it(`should call api'`, () => {
    spyOn(injectedService, 'topAgents').and.returnValue(of());

    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();

    expect(injectedService.topAgents).toHaveBeenCalled();
  });

  it(`should render the list'`, () => {
    let obj = JSON.parse(TestHelper.data);
    spyOn(injectedService, 'topAgents').and.returnValue(of(obj));

    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();

    var liText=fixture.debugElement.query(By.css('#firstList li')).nativeElement.textContent;

    expect(fixture.debugElement.query(By.css('#firstList'))).toBeTruthy();
    expect(liText).toBe(obj[0].makelaarNaam);
  });

});
