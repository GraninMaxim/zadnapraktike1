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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        agentstvoEntities db = agentstvoEntities.GetContext();
        Client1 p1 = new Client1();
        public AddClient()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            StringBuilder errors = new StringBuilder();
            if (ID.Text.Length == 0) errors.AppendLine("Введите ид");
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

            try
            {
                if ((int.Parse(ID.Text) > 1))
                {
                    p1.Id = int.Parse(ID.Text);
                    p1.FirstName = FIO.Text;
                    p1.MiddleName = NAME.Text;
                    p1.LastName = LASTNAME.Text;
                    p1.Phone = PHONE.Text;
                    p1.Email = EMAIL.Text;


                    db.Client1s.Add(p1);
                    db.SaveChanges();
                    MessageBox.Show("Сохранение прошло успешно");
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }

        }
    }
}
