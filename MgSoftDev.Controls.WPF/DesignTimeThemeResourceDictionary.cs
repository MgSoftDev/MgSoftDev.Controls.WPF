using System.Windows;

namespace MgSoftDev.Controls.WPF;


public class DesignTimeThemeResourceDictionary : ResourceDictionary
{
   
    public static bool _IsDesignTime = true;

    /// <summary>
    ///     This class is used to set the design time theme for the application.
    ///     pass uri of the design time theme to the DesignTimeSource property.
    /// </summary>
    public string DesignTimeSource
    {
        get;
        set
        {
            field = value;

            if (!_IsDesignTime) return;

            Source = new Uri(field);
        }
    }

    

    /// <summary>
    ///     This class is used to set the execution time theme for the application.
    ///     pass uri of the execution time theme to the ExecutionTimeSource property.
    /// </summary>
    public string ExecutionTimeSource
    {
        get;
        set
        {
            field = value;

            if (_IsDesignTime) return;

            Source = new Uri(field);
        }
    }

   
}

