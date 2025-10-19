import React from 'react';
import { Car, Calendar, Edit, Trash2 } from 'lucide-react';
import type { VehicleResponseDto } from '../../../types';
import { Button } from '../../shared/components/Button';

interface VehicleCardProps {
  vehicle: VehicleResponseDto;
  onEdit: (vehicle: VehicleResponseDto) => void;
  onDelete: (vehicleId: string) => void;
}

export const VehicleCard: React.FC<VehicleCardProps> = ({
  vehicle,
  onEdit,
  onDelete,
}) => {
  return (
    <div className="bg-white rounded-lg shadow-md hover:shadow-lg transition-shadow duration-200 p-6 border border-gray-200">
      <div className="flex items-start justify-between mb-4">
        <div className="flex items-center space-x-3">
          <div className="bg-blue-100 p-3 rounded-full">
            <Car className="w-6 h-6 text-blue-600" />
          </div>
          <div>
            <h3 className="text-xl font-semibold text-gray-900">
              {vehicle.brand} {vehicle.model}
            </h3>
            <div className="flex items-center text-gray-600 mt-1">
              <Calendar className="w-4 h-4 mr-1" />
              <span className="text-sm">{vehicle.year}</span>
            </div>
          </div>
        </div>
      </div>

      <div className="flex justify-end space-x-2">
        <Button
          variant="outline"
          size="sm"
          onClick={() => onEdit(vehicle)}
          className="px-3 py-2"
          title="Edit vehicle"
        >
          <Edit className="w-4 h-4" />
        </Button>
        <Button
          variant="outline"
          size="sm"
          onClick={() => onDelete(vehicle.id)}
          className="px-3 py-2 text-red-600 border-red-600 hover:bg-red-600 hover:text-white"
          title="Delete vehicle"
        >
          <Trash2 className="w-4 h-4" />
        </Button>
      </div>
    </div>
  );
};
