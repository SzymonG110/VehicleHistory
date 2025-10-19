import type React from 'react';
import { Clock, Shield } from 'lucide-react';

export const About: React.FC = () => {
  const stats = [
    { icon: Clock, label: 'Uptime', value: '99.9%' },
    { icon: Shield, label: 'Data Security', value: '100%' },
  ];

  return (
    <section id="about" className="py-20 bg-gray-50">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="text-center mb-16">
          <h2 className="text-3xl md:text-4xl font-bold text-gray-900 mb-4">
            About VehicleHistory
          </h2>
          <p className="text-xl text-gray-600 max-w-3xl mx-auto">
            We are passionate about helping vehicle owners keep track of their vehicle history 
            and maintenance records in one convenient place.
          </p>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 gap-8 mb-16 max-w-2xl mx-auto">
          {stats.map((stat, index) => {
            const Icon = stat.icon;
            return (
              <div key={index} className="text-center">
                <div className="bg-blue-100 w-16 h-16 rounded-full flex items-center justify-center mx-auto mb-4">
                  <Icon className="w-8 h-8 text-blue-600" />
                </div>
                <div className="text-3xl font-bold text-gray-900 mb-2">{stat.value}</div>
                <div className="text-gray-600">{stat.label}</div>
              </div>
            );
          })}
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-2 gap-12 items-center">
          <div>
            <h3 className="text-2xl font-bold text-gray-900 mb-6">
              Our Mission
            </h3>
            <p className="text-gray-600 mb-6">
              To provide vehicle owners with a comprehensive, user-friendly platform 
              for managing their vehicle history, maintenance records, and important 
              documents all in one place.
            </p>
            <p className="text-gray-600">
              We believe that proper vehicle maintenance tracking leads to better 
              vehicle performance, increased safety, and higher resale value.
            </p>
          </div>
          
          <div className="bg-white rounded-lg shadow-lg p-8">
            <h4 className="text-xl font-semibold text-gray-900 mb-4">
              Why Choose Us?
            </h4>
            <ul className="space-y-3">
              <li className="flex items-start">
                <div className="w-2 h-2 bg-blue-600 rounded-full mt-2 mr-3 flex-shrink-0"></div>
                <span className="text-gray-600">Easy-to-use interface</span>
              </li>
              <li className="flex items-start">
                <div className="w-2 h-2 bg-blue-600 rounded-full mt-2 mr-3 flex-shrink-0"></div>
                <span className="text-gray-600">Secure data storage</span>
              </li>
              <li className="flex items-start">
                <div className="w-2 h-2 bg-blue-600 rounded-full mt-2 mr-3 flex-shrink-0"></div>
                <span className="text-gray-600">Mobile-friendly design</span>
              </li>
              <li className="flex items-start">
                <div className="w-2 h-2 bg-blue-600 rounded-full mt-2 mr-3 flex-shrink-0"></div>
                <span className="text-gray-600">Real-time synchronization</span>
              </li>
              <li className="flex items-start">
                <div className="w-2 h-2 bg-blue-600 rounded-full mt-2 mr-3 flex-shrink-0"></div>
                <span className="text-gray-600">24/7 customer support</span>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </section>
  );
};
