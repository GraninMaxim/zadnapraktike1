using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Zadanie1
{
    /// <summary>
    /// Логика взаимодействия для ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        agentstvoEntities db = agentstvoEntities.GetContext();
        public ClientsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Client1s.Load();
            AgentGrid.ItemsSource = db.Client1s.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddClient f    = new AddClient();
            f.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Client1 row = (Client1)AgentGrid.SelectedItems[0];
                    db.Client1s.Remove(row);
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int indexRow = AgentGrid.SelectedIndex;
            if (indexRow != -1)
            {
                Client1 row = (Client1)AgentGrid.Items[indexRow];
                Class2.Id = row.Id;
                EditClient f = new EditClient();
                f.ShowDialog();
                AgentGrid.Items.Refresh();

            }
        }
    }
}
