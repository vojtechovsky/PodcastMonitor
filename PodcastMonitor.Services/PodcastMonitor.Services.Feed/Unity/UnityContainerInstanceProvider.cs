using System;
using System.Configuration;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace PodcastMonitor.Services.Feed.Unity
{
    /// <summary>
    /// Custom WCF Instance Provider that uses the Unity Container to initialize new service instances.
    /// </summary>
    public class UnityContainerInstanceProvider : IInstanceProvider
    {
        #region Private fields

        /// <summary>
        /// Service type.
        /// </summary>
        private readonly Type _serviceType;

        /// <summary>
        /// Unity container.
        /// </summary>
        private readonly UnityContainer _container;

        #endregion

        /// <summary>
        /// Gets the Unity container instance.
        /// </summary>
        public UnityContainer Container
        {
            get { return _container; }
        }

        /// <summary>
        /// Initializes a new UnityContainerInstanceProvider.
        /// </summary>
        /// <param name="serviceType">The WCF service type.</param>
        public UnityContainerInstanceProvider(Type serviceType)
            : this(serviceType, null)
        {
        }

        /// <summary>
        /// Initializes a new UnityContainerInstanceProvider.
        /// </summary>
        /// <param name="serviceType">The WCF service type.</param>
        /// <param name="containerName">The name of the Unity container configuration.</param>
        public UnityContainerInstanceProvider(Type serviceType, string containerName)
        {
            _serviceType = serviceType;
            _container = new UnityContainer();
            var section = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;
            if (section == null)
            {
                throw new InvalidOperationException("No <unity> configuration section found.");
            }

            if (containerName == null)
            {
                section.Configure(_container);// Containers.Default.Configure(_container);
            }
            else
            {
                section.Configure(_container, containerName);// .Containers[containerName].Configure(_container);
            }
        }

        #region IInstanceProvider Members

        /// <summary>
        /// Returns a service object given the specified System.ServiceModel.InstanceContext object.
        /// </summary>
        /// <param name="instanceContext">The current System.ServiceModel.InstanceContext object.</param>
        /// <returns>A user-defined service object.</returns>
        public object GetInstance(System.ServiceModel.InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        /// <summary>
        /// Returns a service object given the specified System.ServiceModel.InstanceContext object.
        /// </summary>
        /// <param name="instanceContext">The current System.ServiceModel.InstanceContext object.</param>
        /// <param name="message">The message that triggered the creation of a service object.</param>
        /// <returns>A user-defined service object.</returns>
        public object GetInstance(System.ServiceModel.InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
        {
            return _container.Resolve(_serviceType);
        }

        /// <summary>
        /// Called when an System.ServiceModel.InstanceContext object recycles a service object.
        /// </summary>
        /// <param name="instanceContext">The service's instance context.</param>
        /// <param name="instance">The service object to be recycled.</param>
        public void ReleaseInstance(System.ServiceModel.InstanceContext instanceContext, object instance)
        {
            var disposable = instance as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }

        #endregion
    }
}
