using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptiveUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.UI.Xaml;

    // Source:
    // http://social.technet.microsoft.com/wiki/contents/articles/31069.windows-10-apps-leverage-continuum-feature-to-change-ui-for-mousekeyboard-users-using-custom-statetrigger.aspx

    public class ContinuumTrigger : StateTriggerBase
    {
        public string UIMode
        {
            get { return (string)GetValue(UIModeProperty); }
            set { SetValue(UIModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UIMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UIModeProperty =
            DependencyProperty.Register("UIMode", typeof(string), typeof(ContinuumTrigger), new PropertyMetadata(""));

        public ContinuumTrigger()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                WindowActivatedEventHandler windowactivated = null;
                windowactivated = (s, e) =>
                {
                    Windows.UI.Xaml.Window.Current.Activated -= windowactivated;

                    var currentUIMode = Windows.UI.ViewManagement.UIViewSettings.GetForCurrentView().UserInteractionMode.ToString();

                    SetActive(currentUIMode == UIMode);
                };

                Windows.UI.Xaml.Window.Current.Activated += windowactivated;

                Windows.UI.Xaml.Window.Current.SizeChanged += Current_SizeChanged;
            }
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            var currentUIMode = Windows.UI.ViewManagement.UIViewSettings.GetForCurrentView().UserInteractionMode.ToString();
            SetActive(currentUIMode == UIMode);
        }
    }
}
