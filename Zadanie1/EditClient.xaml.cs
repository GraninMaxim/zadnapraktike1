using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Логика взаимодействия для EditClient.xaml
    /// </summary>
    public partial class EditClient : Window
    {
        agentstvoEntities db = agentstvoEntities.GetContext();
        Client1 p2;
        public EditClient()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            p2 = db.Client1s.Find(Class2.Id);
            FIO.Text = p2.FirstName;
            NAME.Text = p2.MiddleName;
            LASTNAME.Text = p2.LastName;
            PHONE.Text = p2.Phone;
            EMAIL.Text = p2.Email;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (FIO.Text.Length == 0) errors.AppendLine("Введите фамилию");
            if (NAME.Text.Length == 0) errors.AppendLine("Введите имя");
            if (LASTNAME.Text.Length == 0) errors.AppendLine("Введите отчество");
            if (PHONE.Text.Length == 0) errors.AppendLine("Введите номер");
            if (EMAIL.Text.Length == 0) errors.AppendLine("Введите емайл");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            p2.FirstName = FIO.Text;
            p2.MiddleName = NAME.Text;
            p2.LastName = LASTNAME.Text;
            p2.Phone = PHONE.Text;
            p2.Email = EMAIL.Text;

            try
            {
                db.SaveChanges();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}

       
   
