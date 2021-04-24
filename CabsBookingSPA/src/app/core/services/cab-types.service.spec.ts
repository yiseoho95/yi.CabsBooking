import { TestBed } from '@angular/core/testing';

import { CabTypesService } from './cab-types.service';

describe('CabTypesService', () => {
  let service: CabTypesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CabTypesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
