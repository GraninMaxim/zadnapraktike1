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
    /// Логика взаимодействия для AgentsWindow.xaml
    /// </summary>

    public partial class AgentsWindow : Window
    {
        agentstvoEntities db = agentstvoEntities.GetContext();
        

        public AgentsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Agents.Load();
            AgentGrid.ItemsSource = db.Agents.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddAgents f = new AddAgents();
            f.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?","Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes) 
            {
                try
                {
                    Agent row = (Agent)AgentGrid.SelectedItems[0];
                    db.Agents.Remove(row);
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
            if(indexRow != -1) 
            {
                Agent row = (Agent)AgentGrid.Items[indexRow];
                Class2.Id = row.Id;
                EditAgent f = new EditAgent();
                f.ShowDialog();
                AgentGrid.Items.Refresh();

            }
        }

        
    }
}
