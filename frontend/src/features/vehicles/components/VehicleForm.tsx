import React, { useState, useEffect } from 'react';
import { Car, Calendar, Save, X } from 'lucide-react';
import type { VehicleDto, VehicleResponseDto } from '../../../types';
import { Button } from '../../shared/components/Button';
import { Input } from '../../shared/components/Input';

interface VehicleFormProps {
  vehicle?: VehicleResponseDto;
  onSubmit: (data: VehicleDto) => void;
  onCancel: () => void;
  isLoading?: boolean;
}

export const VehicleForm: React.FC<VehicleFormProps> = ({
  vehicle,
  onSubmit,
  onCancel,
  isLoading = false,
}) => {
  const [formData, setFormData] = useState<VehicleDto>({
    brand: '',
    model: '',
    year: new Date().getFullYear(),
  });

  useEffect(() => {
    if (vehicle) {
      setFormData({
        brand: vehicle.brand,
        model: vehicle.model,
        year: vehicle.year,
      });
    }
  }, [vehicle]);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSubmit(formData);
  };

  const currentYear = new Date().getFullYear();

  return (
    <div className="w-full max-w-md mx-auto">
      <div className="bg-white rounded-2xl shadow-xl p-8 border border-gray-100">
        <div className="text-center mb-8">
          <div className="w-16 h-16 bg-blue-100 rounded-full flex items-center justify-center mx-auto mb-4">
            <Car className="w-8 h-8 text-blue-600" />
          </div>
          <h2 className="text-2xl font-bold text-gray-900 mb-2">
            {vehicle ? 'Edit Vehicle' : 'Add New Vehicle'}
          </h2>
          <p className="text-gray-600">
            {vehicle ? 'Update your vehicle information' : 'Enter your vehicle details'}
          </p>
        </div>

        <form onSubmit={handleSubmit} className="space-y-6">
          <div className="space-y-4">
            <Input
              label="Brand"
              placeholder="e.g. Toyota, BMW, Ford"
              value={formData.brand}
              onChange={(value) => setFormData({ ...formData, brand: value })}
              required
            />

            <Input
              label="Model"
              placeholder="e.g. Corolla, X5, Focus"
              value={formData.model}
              onChange={(value) => setFormData({ ...formData, model: value })}
              required
            />

            <div>
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Production Year <span className="text-red-500">*</span>
              </label>
              <div className="relative">
                <Calendar className="absolute left-3 top-1/2 transform -translate-y-1/2 w-4 h-4 text-gray-400" />
                <select
                  value={formData.year}
                  onChange={(e) => setFormData({ ...formData, year: parseInt(e.target.value) })}
                  className="w-full pl-10 pr-4 py-3 border border-gray-300 rounded-xl focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent transition-all duration-200 bg-white"
                  required
                >
                  {Array.from({ length: 100 }, (_, i) => currentYear - i).map((year) => (
                    <option key={year} value={year}>
                      {year}
                    </option>
                  ))}
                </select>
              </div>
            </div>
          </div>

          <div className="flex space-x-3 pt-4">
            <Button
              type="submit"
              disabled={isLoading}
              className="flex-1 py-3 text-lg font-semibold"
            >
              {isLoading ? (
                <div className="flex items-center justify-center">
                  <div className="w-4 h-4 border-2 border-white border-t-transparent rounded-full animate-spin mr-2"></div>
                  Saving...
                </div>
              ) : (
                <div className="flex items-center justify-center">
                  <Save className="w-4 h-4 mr-2" />
                  {vehicle ? 'Save Changes' : 'Add Vehicle'}
                </div>
              )}
            </Button>
            <Button
              type="button"
              variant="outline"
              onClick={onCancel}
              className="flex-1 py-3 text-lg font-semibold"
            >
              <X className="w-4 h-4 mr-2" />
              Cancel
            </Button>
          </div>
        </form>
      </div>
    </div>
  );
};
