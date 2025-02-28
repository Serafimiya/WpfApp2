
using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;
using System.Windows;

namespace LibMas
{
    public class Class1
    {
        /// <summary>
        /// ������� ���� ��������� ���������
        /// </summary>
        /// <param name="dataGrid">�������</param>
        /// <param name="mas">������</param>
        /// <param name="tbColumnCount">��������� ���������� �������</param>
        /// <param name="tbDiapozon">��������� ��������� ��������</param>
        /// <param name="listBoxRezult">�������� � ����������� �����������</param>
        public void AllClear(DataGrid dataGrid, int[] mas, TextBox tbColumnCount, TextBox tbDiapozon, TextBox Rez)
        {
            dataGrid.ItemsSource = null;
            mas = null;
            tbColumnCount.Clear();
            tbDiapozon.Clear();
            Rez.Clear();
        }

        /// <summary>
        /// �������� ������� �������
        /// </summary>
        /// <param name="count">���������� ��������� �������</param>
        /// <returns></returns>
        public int[] CreateIntArray(int count)
        {
            int[] mas = new int[count];
            return mas;
        }

        /// <summary>
        /// �������� � ���������� ������� ���������� ������� � ��������� ���������
        /// </summary>
        /// <param name="count">���������� �������� �������</param>
        /// <param name="diapozon">�������� �������� �������</param>
        /// <returns></returns>
        public int[] FillIntArray(int count, int diapozon)
        {
            int[] mas = new int[count];
            Random Rand = new Random();
            for (int i = 0; i < mas.Length; i++) mas[i] = Rand.Next(diapozon);
            return mas;
        }

        /// <summary>
        /// ���������� ������� �� ���������� � ���� ���������� ����
        /// </summary>
        /// <param name="dataGrid">�������</param>
        /// <param name="mas">������</param>
        public void SaveDataToFile(DataGrid dataGrid, int[] mas)
        {
            SaveFileDialog save = new SaveFileDialog
            {
                DefaultExt = ".txt",
                Filter = "��� ����� (*.*)|*.*|��������� �����|*.txt",
                FilterIndex = 2,
                Title = "���������� �������"
            };

            if (dataGrid.ItemsSource != null)
            {
                if (save.ShowDialog() == true)
                {
                    using (StreamWriter file = new StreamWriter(save.FileName))
                    {
                        file.WriteLine(mas.Length);
                        for (int i = 0; i < mas.Length; i++)
                        {
                            file.WriteLine(mas[i]);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("��� ������ ��� ����������.\n������� ��������.", "������:");
            }
        }

        /// <summary>
        /// �������� ����� � ��������
        /// </summary>
        /// <param name="dataGrid">�������</param>
        /// <param name="mas">������</param>
        public void OpenDataToFile(DataGrid dataGrid, int[] mas)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "��� ����� (*.*) | *.* |��������� ����� | *.txt";
            open.FilterIndex = 2;
            open.Title = "���������� �������";

            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);

                int len = Convert.ToInt32(file.ReadLine());
                mas = new Int32[len];
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = Convert.ToInt32(file.ReadLine());
                }
                file.Close();
            }
        }
    }

}
