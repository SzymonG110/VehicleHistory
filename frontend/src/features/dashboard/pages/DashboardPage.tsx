import React from 'react';
import { DashboardHeader } from '../components/DashboardHeader';
import { VehicleList } from '../../vehicles/components/VehicleList';

export const DashboardPage: React.FC = () => {
  return (
    <div className="min-h-screen bg-gray-50">
      <DashboardHeader />
      
      <main className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        <VehicleList />
      </main>
    </div>
  );
};
