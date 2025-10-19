import React from 'react';
import { useAuth } from '../../../contexts/AuthContext';
import { Header } from '../components/Header';
import { Hero } from '../components/Hero';
import { Features } from '../components/Features';
import { About } from '../components/About';
import { Footer } from '../components/Footer';

export const LandingPage: React.FC = () => {
  const { isAuthenticated } = useAuth();

  const handleLogin = () => {
    window.location.href = '/login';
  };

  const handleRegister = () => {
    window.location.href = '/register';
  };

  const handleGetStarted = () => {
    if (isAuthenticated) {
      window.location.href = '/dashboard';
    } else {
      window.location.href = '/register';
    }
  };

  return (
    <div className="min-h-screen bg-white">
      <Header onLogin={handleLogin} onRegister={handleRegister} />
      
      <main>
        <Hero onGetStarted={handleGetStarted} />
        <Features />
        <About />
      </main>
      
      <Footer />
    </div>
  );
};
