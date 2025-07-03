import {AccountService} from './account.service';
import {CourseService} from './course.service';
import {AssignmentService} from './assignment.service';
import {ToastService} from './toast.service';
import {WindowService} from './window.service';

export const services: any[] = [
  AccountService,
  CourseService,
  AssignmentService,
  ToastService,
  WindowService
];

export * from './account.service';
export * from './course.service';
export * from './assignment.service';
export * from './toast.service';
export * from './window.service';
