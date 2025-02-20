using System;
using System.Collections.Generic;
using MahApps.Metro.Controls; // Assurez-vous d'avoir MahApps.Metro installé
using ToastNotifications; // Référence ToastNotifications
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using System.Windows;

namespace MaterialDesignApp
{
    public partial class ExporterWindow : MetroWindow
    {
        private Notifier _notificationManager; // Correctement initialisé comme Notifier

        public ExporterWindow()
        {
            InitializeComponent();



        }
    }
}