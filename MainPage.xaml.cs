using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace AdaptiveUI
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var groups = VisualStateManager.GetVisualStateGroups(LayoutRoot as FrameworkElement);

            Loaded += (s, e) =>
            {
                foreach (var group in groups)
                {
                    if (group.Name == "InputStates")
                    {
                        group.CurrentStateChanged += (src, args) =>
                        {
                            if (args.NewState.Name == "Mouse")
                                MyListView.SelectionMode = ListViewSelectionMode.Single;
                            else
                                MyListView.SelectionMode = ListViewSelectionMode.None;
                        };
                    }
                }
            };

            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size { Width = 320, Height = 400 });
        }
    }
}
