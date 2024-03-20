using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для EditAgent.xaml
    /// </summary>
    public partial class EditAgent : Window
    {
        agentstvoEntities db = agentstvoEntities.GetContext();
        Agent p1;
        public EditAgent()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            p1 = db.Agents.Find(Class2.Id);
            FIO.Text = p1.FirstName;
            NAME.Text = p1.MiddleName;
            LASTNAME.Text = p1.LastName;
            PART.Text = Convert.ToString(p1.DealShare);
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (FIO.Text.Length == 0) errors.AppendLine("Введите фамилию");
            if (NAME.Text.Length == 0) errors.AppendLine("Введите имя");
            if (LASTNAME.Text.Length == 0) errors.AppendLine("Введите отчество");
            if (PART.Text.Length == 0) errors.AppendLine("Введите долю от комисии");

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            p1.FirstName = FIO.Text;
            p1.MiddleName = NAME.Text;
            p1.LastName = LASTNAME.Text;
            p1.DealShare = Convert.ToInt32(PART.Text);

            try 
            {
                db.SaveChanges();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

       
    }
}
