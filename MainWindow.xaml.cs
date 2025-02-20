using System;
using System.Collections.Generic;
using MahApps.Metro.Controls; // Assurez-vous d'avoir MahApps.Metro installé
using ToastNotifications; // Référence ToastNotifications
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using System.Windows;

namespace MaterialDesignApp
{
    public partial class MainWindow : MetroWindow
    {
        private Notifier _notificationManager; // Correctement initialisé comme Notifier

        public MainWindow()
        {
            InitializeComponent();

            // Initialisation de la notification toast avec la configuration nécessaire
            _notificationManager = new Notifier(cfg => cfg.PositionProvider = new WindowPositionProvider(this, Corner.TopRight, 10, 10));

            // Ajouter des données statiques au DataGrid
            var archivedData = new List<ArchivedData>
            {
                new ArchivedData { ID = 1, Name = "Document A", Date = new DateTime(2023, 5, 10), Status = "Archivé" },
                new ArchivedData { ID = 2, Name = "Document B", Date = new DateTime(2023, 6, 15), Status = "Archivé" },
                new ArchivedData { ID = 3, Name = "Document C", Date = new DateTime(2023, 7, 20), Status = "En attente" },
                new ArchivedData { ID = 4, Name = "Document D", Date = new DateTime(2023, 8, 25), Status = "Archivé" }
            };

            // Lier les données au DataGrid
            dataGrid.ItemsSource = archivedData;

        }

        private void ButtonArchive_Click(object sender, RoutedEventArgs e)
        {
            // Display the confirmation dialog
            var result = MessageBox.Show("Êtes-vous sûr de vouloir archiver les données ?",
                                         "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                ArchiveData();

                // Show notification
                notificationPopup.IsOpen = true;

                // Hide the notification after 3 seconds
                var timer = new System.Windows.Threading.DispatcherTimer
                {
                    Interval = TimeSpan.FromSeconds(3)
                };
                timer.Tick += (s, args) =>
                {
                    notificationPopup.IsOpen = false;
                    timer.Stop();
                };
                timer.Start();
            }
        }

        // Placeholder method for archiving logic
        private void ArchiveData()
        {
            // Add the actual archiving logic here
            MessageBox.Show("Les données ont été archivées.");
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            // Instancier et afficher la nouvelle fenêtre
            ExporterWindow exporterWindow = new ExporterWindow();
            exporterWindow.Show(); // Ouvre la fenêtre

            // Si vous voulez ouvrir la fenêtre en mode modal (bloquer l'autre fenêtre)
            // exporterWindow.ShowDialog();
        }


    }


}


    public class ArchivedData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
