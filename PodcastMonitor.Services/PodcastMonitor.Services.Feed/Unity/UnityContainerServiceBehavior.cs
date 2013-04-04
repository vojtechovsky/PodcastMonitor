using System;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace PodcastMonitor.Services.Feed.Unity
{
    /// <summary>
    /// Custom WCF Service Behavior that enables the use of Unity - an IoC/DI container for service instance buildup.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class UnityContainerServiceBehavior : Attribute, IServiceBehavior
    {
        #region Private fields

        /// <summary>
        /// The name of the Unity container.
        /// </summary>
        private readonly string _containerName;

        #endregion

        #region Public constructors

        /// <summary>
        /// Initializes a new <c>UnityContainerServiceBehavior</c> instance.
        /// </summary>
        /// <param name="containerName">Name of the Unity configuration section to use to initialize the container.</param>
        public UnityContainerServiceBehavior(string containerName)
        {
            _containerName = containerName;
        }
        #endregion

        #region IServiceBehavior Members

        /// <summary>
        /// Provides the ability to change run-time property values or insert custom extension objects 
        /// such as error handlers, message or parameter interceptors, security extensions, and other 
        /// custom extension objects.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The host that is currently being built.</param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription,
                                          System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            foreach (var channelDispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                var channelDispatcher = channelDispatcherBase as ChannelDispatcher;

                if (channelDispatcher == null)
                { continue; }

                foreach (var endpointDispatcher in channelDispatcher.Endpoints)
                {
                    endpointDispatcher.DispatchRuntime.InstanceProvider =
                        new UnityContainerInstanceProvider(serviceDescription.ServiceType, _containerName);
                }
            }
        }

        /// <summary>
        /// Provides the ability to pass custom data to binding elements to support the contract implementation.
        /// </summary>
        /// <param name="serviceDescription">The service description of the service.</param>
        /// <param name="serviceHostBase">The host of the service.</param>
        /// <param name="endpoints">The service endpoints.</param>
        /// <param name="bindingParameters">Custom objects to which binding elements have access.</param>
        public void AddBindingParameters(ServiceDescription serviceDescription,
                                         System.ServiceModel.ServiceHostBase serviceHostBase,
                                         System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints,
                                         System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            // Not used in this behavior.
        }

        /// <summary>
        /// Provides the ability to inspect the service host and the service description to confirm 
        /// that the service can run successfully.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The service host that is currently being constructed.</param>
        public void Validate(ServiceDescription serviceDescription,
                             System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            // Not used in this behavior.
        }

        #endregion
    }
}