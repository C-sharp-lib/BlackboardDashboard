import {CanActivateFn, Router} from '@angular/router';
import {inject} from "@angular/core";
import {AccountService} from "../../services";

export const authGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);
  const router = inject(Router);
  if(accountService.isLoggedIn()) {
    return true;
  } else {
    router.navigate(['/account']);
    return false;
  }
}
