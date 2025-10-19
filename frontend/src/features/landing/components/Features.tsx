import React from 'react';
import { 
  Car, 
  Wrench, 
  FileText, 
  Calendar, 
  BarChart3, 
  Smartphone,
  Cloud,
  Lock
} from 'lucide-react';

export const Features: React.FC = () => {
  const features = [
    {
      icon: Car,
      title: 'Vehicle Management',
      description: 'Add, edit and delete vehicles with ease. Store all important information in one place.',
      color: 'blue'
    },
    {
      icon: Wrench,
      title: 'Service History',
      description: 'Track all repairs, inspections and services. Never miss an important deadline.',
      color: 'green'
    },
    {
      icon: FileText,
      title: 'Documents & Invoices',
      description: 'Store documents, invoices and other important files related to vehicles.',
      color: 'purple'
    },
    {
      icon: Calendar,
      title: 'Reminders',
      description: 'Automatic reminders about inspections, insurance and other deadlines.',
      color: 'orange'
    },
    {
      icon: BarChart3,
      title: 'Reports & Statistics',
      description: 'Analyze costs, mileage and other data in clear reports.',
      color: 'indigo'
    },
    {
      icon: Smartphone,
      title: 'Mobile App',
      description: 'Access your data from anywhere with a responsive application.',
      color: 'pink'
    },
    {
      icon: Cloud,
      title: 'Cloud Sync',
      description: 'Your data is automatically synchronized and available on all devices.',
      color: 'cyan'
    },
    {
      icon: Lock,
      title: 'Security',
      description: 'Advanced encryption and security measures protecting your data.',
      color: 'red'
    }
  ];

  const getColorClasses = (color: string) => {
    const colorMap = {
      blue: 'bg-blue-100 text-blue-600',
      green: 'bg-green-100 text-green-600',
      purple: 'bg-purple-100 text-purple-600',
      orange: 'bg-orange-100 text-orange-600',
      indigo: 'bg-indigo-100 text-indigo-600',
      pink: 'bg-pink-100 text-pink-600',
      cyan: 'bg-cyan-100 text-cyan-600',
      red: 'bg-red-100 text-red-600'
    };
    return colorMap[color as keyof typeof colorMap] || 'bg-gray-100 text-gray-600';
  };

  return (
    <section id="features" className="py-20 bg-white">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="text-center mb-16">
          <h2 className="text-3xl md:text-4xl font-bold text-gray-900 mb-4">
            Everything You Need
          </h2>
          <p className="text-xl text-gray-600 max-w-3xl mx-auto">
            Comprehensive tools for managing vehicle history 
            that will make your daily life easier.
          </p>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-8">
          {features.map((feature, index) => {
            const Icon = feature.icon;
            return (
              <div
                key={index}
                className="group p-6 rounded-lg border border-gray-200 hover:border-blue-300 hover:shadow-lg transition-all duration-200"
              >
                <div className={`w-12 h-12 rounded-lg ${getColorClasses(feature.color)} flex items-center justify-center mb-4 group-hover:scale-110 transition-transform duration-200`}>
                  <Icon className="w-6 h-6" />
                </div>
                <h3 className="text-lg font-semibold text-gray-900 mb-2">
                  {feature.title}
                </h3>
                <p className="text-gray-600 text-sm">
                  {feature.description}
                </p>
              </div>
            );
          })}
        </div>
      </div>
    </section>
  );
};
