using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;
using WPFTaskbarNotifier;
using System.Runtime.InteropServices;

namespace WPFTaskbarNotifierExample
{
    /// <summary>
    /// This is just a mock object to hold something of interest. 
    /// </summary>
    

    /// <summary>
    /// This is a TaskbarNotifier that contains a list of NotifyObjects to be displayed.
    /// </summary>
    public partial class ExampleTaskbarNotifier : TaskbarNotifier, INotify
    {
        public ExampleTaskbarNotifier(INotificationHandler handler)
        {
            InitializeComponent();
            this.Topmost = true;
            this.handler = handler;
        }

        private ObservableCollection<NotifyObject> notifyContent;
        /// <summary>
        /// A collection of NotifyObjects that the main window can add to.
        /// </summary>
        public ObservableCollection<NotifyObject> NotifyContent => handler.NotifyContent;
        private readonly INotificationHandler handler;

        //{
        //    get
        //    {
        //        if (this.notifyContent == null)
        //        {
        //            // Not yet created.
        //            // Create it.
        //            this.NotifyContent = new ObservableCollection<NotifyObject>();
        //            this.Topmost = true;
        //        }

        //        return this.notifyContent;
        //    }
        //    set
        //    {
        //        this.notifyContent = value;
        //        this.Topmost = true;
        //    }
        //}

        private void Item_Click(object sender, EventArgs e)
        {
            Hyperlink hyperlink = sender as Hyperlink;

            if(hyperlink == null)
                return;

            NotifyObject notifyObject = hyperlink.Tag as NotifyObject;
            if(notifyObject != null)
            {
                System.Diagnostics.Process.Start("http://localhost/Client-side/auth/login/");
            }
        }

        private void HideButton_Click(object sender, EventArgs e)
        {
            this.ForceHidden();
        }

    }
}