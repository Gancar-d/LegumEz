import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlantationComponent } from './plantation.component';

describe('PlantationComponent', () => {
  let component: PlantationComponent;
  let fixture: ComponentFixture<PlantationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlantationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlantationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
