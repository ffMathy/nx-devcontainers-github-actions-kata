import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MyAngularLib } from './my-angular-lib';

describe('MyAngularLib', () => {
  let component: MyAngularLib;
  let fixture: ComponentFixture<MyAngularLib>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MyAngularLib],
    }).compileComponents();

    fixture = TestBed.createComponent(MyAngularLib);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
