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
using static FinanceTransactions.MainWindow;

namespace FinanceTransactions
{
    /// <summary>
    /// Логика взаимодействия для AddTransactionWindow.xaml
    /// </summary>
    public partial class AddTransactionWindow : Window
    {
        public class TransactionViewModel
        {
            public List<string> Types { get; set; } = new List<string>() { "Доход", "Расход" };
            public List<string> Categories { get; set; } = new List<string>() { "Продукты", "Транспорт", "Развлечения" };
            public DateTime Date { get; set; } = DateTime.Today;
        }
        public TransactionViewModel ViewModel { get; set; }
        public Transaction Transaction { get; set; }
        public AddTransactionWindow()
        {
            InitializeComponent();
            Transaction = new Transaction();
            ViewModel = new TransactionViewModel();
            DataContext = ViewModel;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
