import React, { useState } from 'react';
import { Car, Menu, X, User, LogOut } from 'lucide-react';
import { Link } from 'react-router-dom';
import { useAuth } from '../../../contexts/AuthContext';
import { Button } from '../../shared/components/Button';

interface HeaderProps {
  onLogin: () => void;
  onRegister: () => void;
}

export const Header: React.FC<HeaderProps> = ({ onLogin, onRegister }) => {
  const { isAuthenticated, user, logout } = useAuth();
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  const scrollToSection = (sectionId: string) => {
    const element = document.getElementById(sectionId);
    if (element) {
      element.scrollIntoView({ behavior: 'smooth' });
    }
    setIsMenuOpen(false);
  };

  return (
    <header className="bg-white shadow-sm sticky top-0 z-40">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex justify-between items-center h-16">
          <Link to="/" className="flex items-center space-x-2 hover:opacity-80 transition-opacity">
            <Car className="w-8 h-8 text-blue-600" />
            <span className="text-xl font-bold text-gray-900">VehicleHistory</span>
          </Link>

          <nav className="hidden md:flex items-center space-x-8">
            <button 
              onClick={() => scrollToSection('features')} 
              className="text-gray-600 hover:text-gray-900 transition-colors"
            >
              Features
            </button>
            <button 
              onClick={() => scrollToSection('about')} 
              className="text-gray-600 hover:text-gray-900 transition-colors"
            >
              About
            </button>
            <button 
              onClick={() => scrollToSection('contact')} 
              className="text-gray-600 hover:text-gray-900 transition-colors"
            >
              Contact
            </button>
          </nav>

          <div className="hidden md:flex items-center space-x-4">
            {isAuthenticated ? (
              <>
                <Link to="/dashboard" className="text-gray-600 hover:text-gray-900 transition-colors">
                  Dashboard
                </Link>
                <div className="flex items-center space-x-2 text-gray-700">
                  <User className="w-4 h-4" />
                  <span className="text-sm font-medium">
                    {user?.name} {user?.surname}
                  </span>
                </div>
                <Button 
                  variant="ghost" 
                  size="sm" 
                  onClick={logout}
                  className="px-2"
                  title="Logout"
                >
                  <LogOut className="w-4 h-4" />
                </Button>
              </>
            ) : (
              <>
                <Button variant="ghost" onClick={onLogin}>
                  Sign In
                </Button>
                <Button onClick={onRegister}>
                  Sign Up
                </Button>
              </>
            )}
          </div>

          <button
            className="md:hidden p-2 rounded-md text-gray-600 hover:text-gray-900 hover:bg-gray-100"
            onClick={() => setIsMenuOpen(!isMenuOpen)}
          >
            {isMenuOpen ? <X className="w-6 h-6" /> : <Menu className="w-6 h-6" />}
          </button>
        </div>

        {isMenuOpen && (
          <div className="md:hidden border-t border-gray-200 py-4">
            <nav className="flex flex-col space-y-4">
              <button 
                onClick={() => scrollToSection('features')} 
                className="text-gray-600 hover:text-gray-900 transition-colors text-left"
              >
                Features
              </button>
              <button 
                onClick={() => scrollToSection('about')} 
                className="text-gray-600 hover:text-gray-900 transition-colors text-left"
              >
                About
              </button>
              <button 
                onClick={() => scrollToSection('contact')} 
                className="text-gray-600 hover:text-gray-900 transition-colors text-left"
              >
                Contact
              </button>
              <div className="flex flex-col space-y-2 pt-4 border-t border-gray-200">
                {isAuthenticated ? (
                  <>
                    <Link to="/dashboard" className="text-gray-600 hover:text-gray-900 transition-colors py-2">
                      Dashboard
                    </Link>
                    <div className="flex items-center space-x-2 text-gray-700 py-2">
                      <User className="w-4 h-4" />
                      <span className="text-sm font-medium">
                        {user?.name} {user?.surname}
                      </span>
                    </div>
                    <Button 
                      variant="ghost" 
                      onClick={logout} 
                      className="justify-start px-2"
                      title="Logout"
                    >
                      <LogOut className="w-4 h-4 mr-2" />
                      Logout
                    </Button>
                  </>
                ) : (
                  <>
                    <Button variant="ghost" onClick={onLogin} className="justify-start">
                      Sign In
                    </Button>
                    <Button onClick={onRegister} className="justify-start">
                      Sign Up
                    </Button>
                  </>
                )}
              </div>
            </nav>
          </div>
        )}
      </div>
    </header>
  );
};
