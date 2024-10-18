
using System.Data;
using System.Windows;

namespace Lib_5
{
    public static class VisualArray
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this T[] arr)
        {
            var res = new DataTable();
            for (int i = 0; i < arr.Length; i++)
            {
                res.Columns.Add("Элемент №" + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++)
            {
                row[i] = arr[i];
            }
            res.Rows.Add(row);
            return res;
        }


        public static int CalculatorFunkcion(int[] mas, ref bool rezultbool)
        {
            rezultbool = false;
            int rezult = 1;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] < 3)
                {
                    rezult = rezult * mas[i];
                    rezultbool = true;
                }
            }
            return rezult;
        }
    }
}
