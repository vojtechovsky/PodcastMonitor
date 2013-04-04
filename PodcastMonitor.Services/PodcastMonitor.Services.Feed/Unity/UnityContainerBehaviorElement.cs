using System;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace PodcastMonitor.Services.Feed.Unity
{
    /// <summary>
    /// Extension Behavior Element to set up the use of the Unity Container behavior.
    /// </summary>
    public class UnityContainerBehaviorElement : BehaviorExtensionElement
    {
        /// <summary>
        /// Name of the configuration attribute for the container name.
        /// </summary>
        private const string ContainerConfigurationPropertyName = "containerName";

        /// <summary>
        /// Gets or sets the Unity container to use.
        /// </summary>
        /// <value>The name of the Unity container configuration section.</value>
        [ConfigurationProperty(ContainerConfigurationPropertyName, IsRequired = true)]
        public string ContainerName
        {
            get { return (string)base[ContainerConfigurationPropertyName]; }
            set { base[ContainerConfigurationPropertyName] = value; }
        }

        /// <summary>
        /// Gets the type of behavior.
        /// </summary>
        /// <value></value>
        /// <returns>A <see cref="T:System.Type"/>.</returns>
        public override Type BehaviorType
        {
            get { return typeof(UnityContainerServiceBehavior); }
        }

        /// <summary>
        /// Creates a behavior extension based on the current configuration settings.
        /// </summary>
        /// <returns>The behavior extension.</returns>
        protected override object CreateBehavior()
        {
            return new UnityContainerServiceBehavior(ContainerName);
        }
    }
}