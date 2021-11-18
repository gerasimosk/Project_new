import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import {Title} from "@angular/platform-browser";

import { IUserTitle } from 'src/app/models/userTitle.model';
import { IUserType } from 'src/app/models/userType.model';
import { IUser } from '../../models/user.model';
import { UserService } from '../../services/user.service';
import { ToastrService } from 'ngx-toastr';
import { UserTypeService } from 'src/app/services/userType.service';
import { UserTitleService } from 'src/app/services/userTitle.service';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css'],
})
export class UserDetailsComponent implements OnInit {
  editMode = false;
  user: IUser = null;
  userTypes: IUserType[] = [];
  userTitles: IUserTitle[] = [];
  id: number = null;
  userForm: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private userTypeService: UserTypeService,
    private userTitleService: UserTitleService,
    private toastr: ToastrService,
    private titleService:Title
  ) {}

  async ngOnInit() {
    this.route.params.subscribe(async (params: Params) => {
      this.id = +params['id'];
      if (Number.isNaN(this.id)) {
        this.editMode = false;
        this.titleService.setTitle("Add user");
      } else {
        this.editMode = true;
      }
      if (this.editMode) {
        this.user = await this.userService.getUser(this.id);
        this.titleService.setTitle(this.user.name + " " + this.user.surname);
      }
      this.initForm();
    });

    try {
      this.userTypes = await this.userTypeService.getUserType();
      this.userTitles = await this.userTitleService.getUserTitle();
    } catch (error) {
      this.toastr.error('Problem while loading dropdowns', 'Loading');
    }
  }

  private initForm() {
    let id = null;
    let name = '';
    let surname = '';
    let birthDate = null;
    let userTypeId = null;
    let userTitleId = null;
    let emailAddress = '';
    let isActive = null;

    if (this.editMode && this.user) {
      (id = this.user.id), (name = this.user.name);
      surname = this.user.surname;
      birthDate = formatDate(this.user.birthDate, 'yyyy-MM-dd', 'en-US');
      userTypeId = this.user.userTypeId;
      userTitleId = this.user.userTitleId;
      emailAddress = this.user.emailAddress;
      isActive = this.user.isActive;
    }

    this.userForm = new FormGroup({
      id: new FormControl(id),
      name: new FormControl(name, Validators.maxLength(20)),
      surname: new FormControl(surname, Validators.maxLength(20)),
      birthDate: new FormControl(birthDate),
      userTypeId: new FormControl(userTypeId, Validators.required),
      userTitleId: new FormControl(userTitleId, Validators.required),
      emailAddress: new FormControl(emailAddress, [
        Validators.email,
        Validators.maxLength(50),
      ]),
      isActive: new FormControl(isActive),
    });
  }

  onCancel() {
    this.router.navigate(['../'], { relativeTo: this.route });
  }

  async onSubmit() {
    if (this.editMode) {
      try {
        const toIntegerValues = {
          ...this.userForm.value,
          userTitleId: +this.userForm.value.userTitleId,
          userTypeId: +this.userForm.value.userTypeId,
        };
        await this.userService.updateUser(toIntegerValues);
        this.toastr.success('User successfully updated!', 'Update');
        this.user = toIntegerValues;
        this.titleService.setTitle(this.user.name + " " + this.user.surname);
      } catch (error) {
        this.toastr.error('Problem while updating the user!', 'Update');
      }
    } else {
      try {
        const toIntegerValues = {
          ...this.userForm.value,
          userTitleId: +this.userForm.value.userTitleId,
          userTypeId: +this.userForm.value.userTypeId,
          isActive: true,
          id: 0,
        };
        await this.userService.addUser(toIntegerValues);
        this.toastr.success('User added successfully!', 'Add');
        this.user = toIntegerValues;
        this.titleService.setTitle(this.user.name + " " + this.user.surname);
      } catch (error) {
        this.toastr.error('Problem while adding the user!', 'Add');
      }
    }
  }
}
