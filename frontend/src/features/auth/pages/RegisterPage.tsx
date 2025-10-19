import type React from 'react';
import { Link } from 'react-router-dom';
import { Car } from 'lucide-react';
import { RegisterForm } from '../components/RegisterForm';

export const RegisterPage: React.FC = () => {
  return (
    <div className="min-h-screen bg-gradient-to-br from-green-50 to-emerald-100 flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8">
      <div className="max-w-md w-full space-y-8">
        <div className="text-center">
          <Link to="/" className="inline-flex items-center space-x-2 text-green-600 hover:text-green-800 transition-colors">
            <Car className="w-8 h-8" />
            <span className="text-xl font-bold">VehicleHistory</span>
          </Link>
        </div>

        <RegisterForm />

        <div className="text-center">
          <p className="text-gray-600">
            Already have an account?{' '}
            <Link 
              to="/login" 
              className="text-green-600 hover:text-green-800 font-semibold transition-colors"
            >
              Sign in here
            </Link>
          </p>
        </div>
      </div>
    </div>
  );
};
