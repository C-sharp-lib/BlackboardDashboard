export interface User {
  id: string;
  email: string;
  userName: string;
  phoneNumber?: string;
  firstName?: string;
  middleName?: string;
  lastName?: string;
  address?: string;
  city?: string;
  state?: string;
  zipCode?: string;
  description?: string;
  dateOfBirth?: Date;
  dateJoined?: Date;
  dateLastLogin?: Date;
  dateUpdated?: Date;
  imageUrl?: string;
  userRoles?: UserRoles[];
}
export interface Role {
  id: string;
  name: string;
  description?: string;
}
export interface UserRoles {
  roleId?: number;
  role: Role;
  userId?: number;
  user: User;
}
