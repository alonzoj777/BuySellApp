import { CanActivateFn, Router } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { inject } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

export const authGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);

  if(accountService.currentUser()) {
    return true;
  }else {
    inject(ToastrService).error('You must be logged in to access this page');
    inject(Router).navigateByUrl('/');
    return false;
  }
 
};
