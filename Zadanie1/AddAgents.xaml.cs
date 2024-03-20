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
    /// Логика взаимодействия для AddAgents.xaml
    /// </summary>
    public partial class AddAgents : Window
    {
        agentstvoEntities db = agentstvoEntities.GetContext();
        Agent p1 = new Agent();
        public AddAgents()
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
            if (PART.Text.Length == 0) errors.AppendLine("Введите долю от комисии");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            try
            {
                if ((int.Parse(ID.Text) > 1)&&(int.Parse(PART.Text)>0 && int.Parse(PART.Text)<101)) 
                {
                    p1.Id = int.Parse(ID.Text);
                    p1.FirstName = FIO.Text;
                    p1.MiddleName = NAME.Text;
                    p1.LastName = LASTNAME.Text;
                    p1.DealShare = int.Parse(PART.Text);


                    db.Agents.Add(p1);
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
