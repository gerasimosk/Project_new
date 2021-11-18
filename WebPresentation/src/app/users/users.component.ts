import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { async, Subscription } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import {Title} from "@angular/platform-browser";

import { IUser } from '../models/user.model';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
})
export class UsersComponent implements OnInit, OnDestroy {
  users: IUser[] = [];
  isLoading = false;
  fullNameFilter = new FormControl('');
  private fullNameFilterSub: Subscription;
  pageNumber = 1;
  pageSize = 10;
  numberOfUsers = 0;

  constructor(
    private userService: UserService,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private titleService:Title
  ) {
    this.titleService.setTitle("Users");
  }

  async ngOnInit() {
    this.fullNameFilterSub = this.fullNameFilter.valueChanges.subscribe(
      async () => {
        await this.getUsers();
      }
    );

    this.isLoading = true;
    await this.getUsers();
    this.isLoading = false;
  }

  userSelected(user: IUser) {
    this.router.navigate([user.id], { relativeTo: this.route });
  }

  async getUsers() {
    this.users = await this.userService.getUsers(
      this.pageNumber,
      this.pageSize,
      this.fullNameFilter.value
    );
    this.numberOfUsers = await this.userService.getCountOfUsers(
      this.fullNameFilter.value
    );
  }

  async refreshUsers() {
    await this.getUsers();
  }

  async onDelete(index: number) {
    if (
      confirm(
        'Are you sure you want to delete user: ' +
          this.users[index].name +
          ' ' +
          this.users[index].surname +
          '?'
      )
    ) {
      try {
        await this.userService.deleteUser(this.users[index].id);
        this.toastr.success('User deleted successfully!', 'Delete');
        await this.getUsers();
      } catch (error) {
        this.toastr.error('Problem while deleting the user!', 'Delete');
      }
    }
  }

  onAddUser() {
    this.router.navigate(['new'], { relativeTo: this.route });
  }

  ngOnDestroy(): void {
    this.fullNameFilterSub.unsubscribe();
  }
}
