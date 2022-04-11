/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/

using System.Collections.Generic;
using SharpGlue.Base;

namespace SharpGlue.Core
{
    /// <summary>
    /// Represents a container for all <see cref="Base.IServiceProvider"/>s
    /// </summary>
    public class ServiceContainer
    {
        List<IServiceProvider> _services;

        /// <summary>
        /// Gets or sets a service.
        /// </summary>
        /// <param name="name">The name of the service.</param>
        /// <returns></returns>
        public IServiceProvider this[string name]
        {
            get => GetService<IServiceProvider>(name);
            set => _updateService(name, value);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="ServiceContainer"/>
        /// </summary>
        public ServiceContainer() {
            _services = new List<IServiceProvider>();
        }

        /// <summary>
        /// Adds a service.
        /// </summary>
        /// <typeparam name="T">The type of service to add.</typeparam>
        /// <param name="service">The service.</param>
        public void AddService<T>(T service) where T : IServiceProvider {
            _services.Add(service);
        }
        
        /// <summary>
        /// Gets a service.
        /// </summary>
        /// <typeparam name="T">The type of service to return.</typeparam>
        /// <param name="name">The name of the service.</param>
        /// <returns></returns>
        public T GetService<T>(string name) where T:IServiceProvider {
            IServiceProvider service = null;
            foreach (var serv in _services)
                if (serv.ServiceName == name)
                    service = (T)serv;
            return (T)service;
        }

        #region private
        void _updateService(string serviceName, IServiceProvider newUpdate) {
            for (int i = 0; i < _services.Count; i++)
                if (_services[i].ServiceName == serviceName)
                    _services[i] = newUpdate;
        }
        #endregion
    }
}
