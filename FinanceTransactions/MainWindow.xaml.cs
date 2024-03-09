using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FinanceTransactions
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Transaction
        {
            public DateTime Date { get; set; }
            public string Type { get; set; }
            public decimal Amount { get; set; }
            public string Category { get; set; }
            public string Description { get; set; }
        }
        private List<Transaction> transactions;
        public MainWindow()
        {
            InitializeComponent();
            transactions = new List<Transaction>() {
                new Transaction()
                {
                    Date = DateTime.Today.AddDays(-2),
                    Type = "Доход",
                    Amount = 500,
                    Category = "Подарок",
                    Description = "Подарок от друга"
                },
                new Transaction()
                {
                    Date = DateTime.Today.AddDays(-3),
                    Type = "Расход",
                    Amount = 200,
                    Category = "Продукты",
                    Description = "Покупка продуктов в магазине"
                },
                new Transaction()
                {
                    Date = DateTime.Today.AddDays(-4),
                    Type = "Расход",
                    Amount = 50,
                    Category = "Транспорт",
                    Description = "Проезд на автобусе"
                },
                new Transaction()
                {
                    Date = DateTime.Today.AddDays(-5),
                    Type = "Расход",
                    Amount = 100,
                    Category = "Развлечения",
                    Description = "Поход в кино"
                },
                new Transaction()
                {
                    Date = DateTime.Today.AddDays(-6),
                    Type = "Доход",
                    Amount = 2000,
                    Category = "Фриланс",
                    Description = "Оплата за выполненный проект"
                },
                new Transaction()
                {
                    Date = DateTime.Today.AddDays(-7),
                    Type = "Расход",
                    Amount = 150,
                    Category = "Кафе",
                    Description = "Обед в кафе"
                },
                new Transaction()
                {
                    Date = DateTime.Today.AddDays(-8),
                    Type = "Расход",
                    Amount = 300,
                    Category = "Одежда",
                    Description = "Покупка новой футболки"
                },
                new Transaction()
                {
                    Date = DateTime.Today.AddDays(-9),
                    Type = "Доход",
                    Amount = 100,
                    Category = "Проценты",
                    Description = "Начисление процентов на депозит"
                },
                new Transaction()
                {
                    Date = DateTime.Today.AddDays(-10),
                    Type = "Расход",
                    Amount = 75,
                    Category = "Спорт",
                    Description = "Покупка абонемента в спортзал"
                },
                new Transaction()
                {
                    Date = DateTime.Today,
                    Type = "Доход",
                    Amount = 1000,
                    Category = "Зарплата",
                    Description = "Заработная плата за месяц"
                },
                new Transaction()
                {
                    Date = DateTime.Today.AddDays(-2),
                    Type = "Доход",
                    Amount = 500,
                    Category = "Подарок",
                    Description = "Подарок от друга"
                },
                new Transaction()
                {
                    Date = DateTime.Today,
                    Type = "Расход",
                    Amount = 200,
                    Category = "Продукты",
                    Description = "Покупка продуктов в магазине"
                },
                new Transaction()
                {
                    Date = DateTime.Today.AddDays(-1),
                    Type = "Расход",
                    Amount = 50,
                    Category = "Транспорт",
                    Description = "Проезд на автобусе"
                },
                new Transaction()
                {
                    Date = DateTime.Today.AddDays(-3),
                    Type = "Расход",
                    Amount = 100,
                    Category = "Развлечения",
                    Description = "Поход в кино"
                },
                new Transaction()
                {
                    Date = DateTime.Today,
                    Type = "Перевод",
                    Amount = 500,
                    Category = "Переводы",
                    Description = "Перевод денег другу"
                },
                new Transaction()
                {
                    Date = DateTime.Today.AddDays(-1),
                    Type = "Начисление",
                    Amount = 100,
                    Category = "Проценты",
                    Description = "Начисление процентов на депозит"
                }
            };
            
            dgTransactions.ItemsSource = transactions;
            btnDelete.IsEnabled = false;
        }

        private void btnAddTransaction_Click(object sender, RoutedEventArgs e)
        {
            var addTransactionWindow = new AddTransactionWindow();
            if (addTransactionWindow.ShowDialog() == true)
            {
                transactions.Add(addTransactionWindow.Transaction);
                dgTransactions.ItemsSource = null;
                dgTransactions.ItemsSource = transactions;
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            dgTransactions.ItemsSource = null;
            dgTransactions.ItemsSource = transactions;
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            var filteredTransactions = transactions.Where(t => t.Description.Contains(txtSearch.Text) || t.Amount.ToString().Contains(txtSearch.Text) || t.Category.Contains(txtSearch.Text) || t.Date.ToString().Contains(txtSearch.Text));
            dgTransactions.ItemsSource = null;
            dgTransactions.ItemsSource = filteredTransactions;
        }

        private void dgTransactions_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if(dgTransactions.SelectedItem != null) btnDelete.IsEnabled = true;
            else btnDelete.IsEnabled = false;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedTransaction = dgTransactions.SelectedItem as Transaction;
            if (selectedTransaction != null)
            {
                if (MessageBox.Show("Удалить транзакцию?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    transactions.Remove(selectedTransaction);
                    dgTransactions.ItemsSource = null;
                    dgTransactions.ItemsSource = transactions;
                }
            }
        }
    }
}
