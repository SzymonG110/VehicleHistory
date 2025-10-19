import React, { useState, useEffect } from 'react';
import { Plus, Car } from 'lucide-react';
import { apiService } from '../../../services/api';
import type { VehicleResponseDto, VehicleDto } from '../../../types';
import { Button } from '../../shared/components/Button';
import { VehicleCard } from './VehicleCard';
import { VehicleForm } from './VehicleForm';
import { Modal } from '../../shared/components/Modal';
import { LoadingSpinner } from '../../shared/components/LoadingSpinner';

export const VehicleList: React.FC = () => {
  const [vehicles, setVehicles] = useState<VehicleResponseDto[]>([]);
  const [isLoading, setIsLoading] = useState(true);
  const [isFormOpen, setIsFormOpen] = useState(false);
  const [editingVehicle, setEditingVehicle] = useState<VehicleResponseDto | undefined>();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [error, setError] = useState('');

  useEffect(() => {
    loadVehicles();
  }, []);

  const loadVehicles = async () => {
    try {
      setIsLoading(true);
      const response = await apiService.getVehicles();
      setVehicles(response.data);
    } catch (err) {
      setError('Failed to load vehicles');
      console.error('Error loading vehicles:', err);
    } finally {
      setIsLoading(false);
    }
  };

  const handleAddVehicle = () => {
    setEditingVehicle(undefined);
    setIsFormOpen(true);
  };

  const handleEditVehicle = (vehicle: VehicleResponseDto) => {
    setEditingVehicle(vehicle);
    setIsFormOpen(true);
  };

  const handleDeleteVehicle = async (vehicleId: string) => {
    if (!window.confirm('Are you sure you want to delete this vehicle?')) {
      return;
    }

    try {
      await apiService.deleteVehicle(vehicleId);
      setVehicles(vehicles.filter(v => v.id !== vehicleId));
    } catch (err) {
      setError('Failed to delete vehicle');
      console.error('Error deleting vehicle:', err);
    }
  };

  const handleSubmitVehicle = async (data: VehicleDto) => {
    try {
      setIsSubmitting(true);
      
      if (editingVehicle) {
        const response = await apiService.updateVehicle(editingVehicle.id, data);
        setVehicles(vehicles.map(v => v.id === editingVehicle.id ? response.data : v));
      } else {
        const response = await apiService.createVehicle(data);
        setVehicles([...vehicles, response.data]);
      }
      
      setIsFormOpen(false);
      setEditingVehicle(undefined);
    } catch (err) {
      setError(editingVehicle ? 'Failed to update vehicle' : 'Failed to add vehicle');
      console.error('Error saving vehicle:', err);
    } finally {
      setIsSubmitting(false);
    }
  };

  const handleCloseForm = () => {
    setIsFormOpen(false);
    setEditingVehicle(undefined);
  };

  if (isLoading) {
    return (
      <div className="flex justify-center items-center h-64">
        <LoadingSpinner size="lg" />
      </div>
    );
  }

  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h2 className="text-2xl font-bold text-gray-900">My Vehicles</h2>
        <Button onClick={handleAddVehicle} className="flex items-center space-x-2">
          <Plus className="w-5 h-5" />
          <span>Add Vehicle</span>
        </Button>
      </div>

      {error && (
        <div className="bg-red-50 border border-red-200 text-red-700 px-4 py-3 rounded-lg">
          {error}
        </div>
      )}

      {vehicles.length === 0 ? (
        <div className="text-center py-12">
          <Car className="w-16 h-16 text-gray-400 mx-auto mb-4" />
          <h3 className="text-lg font-medium text-gray-900 mb-2">No Vehicles</h3>
          <p className="text-gray-600 mb-4">Add your first vehicle to start tracking its history.</p>
          <Button onClick={handleAddVehicle}>
            Add First Vehicle
          </Button>
        </div>
      ) : (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {vehicles.map((vehicle) => (
            <VehicleCard
              key={vehicle.id}
              vehicle={vehicle}
              onEdit={handleEditVehicle}
              onDelete={handleDeleteVehicle}
            />
          ))}
        </div>
      )}

      <Modal
        isOpen={isFormOpen}
        onClose={handleCloseForm}
        size="md"
      >
        <VehicleForm
          vehicle={editingVehicle}
          onSubmit={handleSubmitVehicle}
          onCancel={handleCloseForm}
          isLoading={isSubmitting}
        />
      </Modal>
    </div>
  );
};
