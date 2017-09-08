﻿using Rigio.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rigio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RigioPage : ContentPage
    {
        public RigioPage()
        {
            FloatingActionButtonView _Fab;
            ScrollView _ScrollView;

            InitializeComponent();

            _ScrollView = new ScrollView
            {
                Content = new StackLayout
                {
                    Spacing = 0,
                    Children =
                    {
                       
                    }
                }
            };

            #region compose view hierarchy
            if (Device.OS == TargetPlatform.Android)
            {
                _Fab = new FloatingActionButtonView
                {
                    ImageName = "fab_add.png",
                    ColorNormal = Color.FromHex("53BA9D"),
                    ColorPressed = Color.FromHex("42947D"),
                    ColorRipple = Color.FromHex("53BA9D")
                };

                var absolute = new AbsoluteLayout
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                };

                // Position the pageLayout to fill the entire screen.
                // Manage positioning of child elements on the page by editing the pageLayout.
                AbsoluteLayout.SetLayoutFlags(_ScrollView, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(_ScrollView, new Rectangle(0f, 0f, 1f, 1f));
                absolute.Children.Add(_ScrollView);

                // Overlay the FAB in the bottom-right corner
                AbsoluteLayout.SetLayoutFlags(_Fab, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(_Fab, new Rectangle(1f, 1f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
                absolute.Children.Add(_Fab);

                Content = absolute;
            }
            else
            {
                var syncButton = new ToolbarItem
                {
                    Text = "Add",
                    Icon = "add_ios_gray",
                    //Order = ToolbarItemOrder.Primary
                };

                ToolbarItems.Add(syncButton);

                Content = _ScrollView;
            }
            #endregion
        }
    }
}