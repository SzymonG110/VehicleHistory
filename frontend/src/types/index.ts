export interface AuthLoginDto {
  email: string;
  password: string;
}

export interface AuthRegisterDto {
  name: string;
  surname: string;
  email: string;
  password: string;
  confirmPassword: string;
}

export interface AuthTokens {
  accessToken: string;
  refreshToken: string;
}

export interface VehicleDto {
  brand: string;
  model: string;
  year: number;
}

export interface VehicleResponseDto {
  id: string;
  brand: string;
  model: string;
  year: number;
  userId: string;
}

export interface User {
  id: string;
  name: string;
  surname: string;
  email: string;
}

export interface ApiResponse<T> {
  data?: T;
  error?: string;
  message?: string;
}
