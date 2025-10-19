import axios from 'axios';
import type { AxiosInstance, AxiosResponse } from 'axios';
import type { AuthLoginDto, AuthRegisterDto, AuthTokens, VehicleDto, VehicleResponseDto, User } from '../types';

class ApiService {
  private api: AxiosInstance;

  constructor() {
    this.api = axios.create({
      baseURL: '/api',
      headers: {
        'Content-Type': 'application/json',
      },
    });

    this.api.interceptors.request.use(
      (config) => {
        const token = localStorage.getItem('accessToken');
        if (token) {
          config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
      },
      (error) => Promise.reject(error)
    );

    this.api.interceptors.response.use(
      (response) => response,
      async (error) => {
        const originalRequest = error.config;
        
        if (error.response?.status === 401 && !originalRequest._retry) {
          originalRequest._retry = true;
          
          try {
            const refreshToken = localStorage.getItem('refreshToken');
            if (refreshToken) {
              const response = await this.refreshToken(refreshToken);
              localStorage.setItem('accessToken', response.data.accessToken);
              localStorage.setItem('refreshToken', response.data.refreshToken);
              
              originalRequest.headers.Authorization = `Bearer ${response.data.accessToken}`;
              return this.api(originalRequest);
            }
          } catch (refreshError) {
            localStorage.removeItem('accessToken');
            localStorage.removeItem('refreshToken');
            window.location.href = '/';
          }
        }
        
        return Promise.reject(error);
      }
    );
  }

  async register(data: AuthRegisterDto): Promise<AxiosResponse<AuthTokens>> {
    return this.api.post('/auth/register', data);
  }

  async login(data: AuthLoginDto): Promise<AxiosResponse<AuthTokens>> {
    return this.api.post('/auth/login', data);
  }

  async refreshToken(refreshToken: string): Promise<AxiosResponse<AuthTokens>> {
    return this.api.post('/auth/refresh', { refreshToken });
  }

  async getCurrentUser(): Promise<AxiosResponse<User>> {
    return this.api.get('/user/me');
  }

  async getVehicles(): Promise<AxiosResponse<VehicleResponseDto[]>> {
    return this.api.get('/vehicle');
  }

  async getVehicleById(id: string): Promise<AxiosResponse<VehicleResponseDto>> {
    return this.api.get(`/vehicle/${id}`);
  }

  async createVehicle(data: VehicleDto): Promise<AxiosResponse<VehicleResponseDto>> {
    return this.api.post('/vehicle', data);
  }

  async updateVehicle(id: string, data: VehicleDto): Promise<AxiosResponse<VehicleResponseDto>> {
    return this.api.put(`/vehicle/${id}`, data);
  }

  async deleteVehicle(id: string): Promise<AxiosResponse<void>> {
    return this.api.delete(`/vehicle/${id}`);
  }
}

export const apiService = new ApiService();
