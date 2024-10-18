using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibMas;
using Lib_5;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnProgInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ввести n целых чисел. Найти произведение чисел < 3. Результат вывести на экран.", "Задание: ");
        }

        private void btnRazrab_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ФИО: Лосева Анастасия Игоревна" +
                "\n Практическая работа №2", "Разработчик");
        }

        int[] mas;
        bool rezultbool;

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(tbDiapozon.Text, out int randMax))
            {
                randMax = Convert.ToInt32(tbDiapozon.Text);
            }
            else MessageBox.Show("Введите корректное значение!", "Ошибка:");
            if (Int32.TryParse(tbColumnCount.Text, out int count))
            {
                count = Convert.ToInt32(tbColumnCount.Text);

                Class1 fill = new Class1();
                mas = fill.FillIntArray(count, randMax);
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
            else MessageBox.Show("Введите корректное значение!", "Ошибка:");
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column is DataGridTextColumn)
            {
                TextBox textBox = e.EditingElement as TextBox;
                if (textBox != null)
                {
                    if (int.TryParse(textBox.Text, out int value))
                    {
                        int indexColumn = e.Column.DisplayIndex;
                        mas[indexColumn] = Convert.ToInt32(value);
                    }
                    else MessageBox.Show("Введите корректное значение!", "Ошибка:");
                }
            }
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            Rez.Clear();
            int squareRoots = Lib_5.VisualArray.CalculatorFunkcion(mas, ref rezultbool);
            if (rezultbool == false)
            {
                MessageBox.Show("Нет верных значений", "Ошибка:");
            }
            else Rez.Text = squareRoots.ToString();

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Class1 clear = new Class1();
            clear.AllClear(dataGrid, mas, tbColumnCount, tbDiapozon, Rez);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(tbColumnCount.Text, out int count))
            {
                count = Convert.ToInt32(tbColumnCount.Text);
                Class1 create = new Class1();
                mas = create.CreateIntArray(count);
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
            else MessageBox.Show("Введите кол-во колонок!", "Ошибка:");
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Class1 SaveFileManager = new Class1();
            SaveFileManager.SaveDataToFile(dataGrid, mas);
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            Class1 OpenFileMenedger = new Class1();
            OpenFileMenedger.OpenDataToFile(dataGrid, mas);
            dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
        }
    }
}