using System;
using System.Web.Mvc;


namespace PodcastMonitor.Web.UI.Common
{
    public class DisplayModeAttribute : Attribute, IMetadataAware
    {
        public DisplayMode DisplayMode { get; private set; }

        public DisplayModeAttribute(DisplayMode displayMode)
        {
            DisplayMode = displayMode;
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            switch (DisplayMode)
            {
                case DisplayMode.DisplayOnly:
                    metadata.ShowForEdit = false;
                    break;
                case DisplayMode.EditOnly:
                    metadata.ShowForDisplay = false;
                    break;
                default:
                    metadata.ShowForDisplay = false;
                    metadata.ShowForEdit = false;
                    break;
            }
        }

    }
    public enum DisplayMode
    {
        None,
        DisplayOnly,
        EditOnly
    }
}

    
