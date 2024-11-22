using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    static public class DataFailureClass
    {
        public static bool IsRepeating(string row) //Проверка уникальности символов в строке
        {
            List<char> symbols = new List<char>();

            foreach (char ch in row) //перебор символов в строке
            {
                if (symbols.Contains(ch)) //если символ ещё не содержится в списке, добавляем его, в противном случае возвращаем false
                    return false;
                else
                    symbols.Add(ch);
            }
            return true; //если все элементы уникальны, возвращаем true
        }

        public static bool IsLetterAndUpper(string row) //совершенствуем метод IsLetter из класса string, добавляя в него проверку на верхний регистр
        {
            foreach (char ch in row)
            {
                if (!char.IsLetter(ch) || !char.IsUpper(ch))
                    return false;
            }
            return true;
        }

        public static bool IsCorrectlLength(string row) //метод, проверяющий длину строки
        {
            if (row.Length > 0 && row.Length < 27) //количество символов должно быть в диапозоне от 1 до 26 символов включительно
                return true;
            return false;
        }

        public static bool IsFileExisting(string fileName) //проверка на название входного файла, чтобы он был только input.txt
        {
            if (fileName == "input.txt")
                return true;
            return false;
        }

        public static string Converting(string line) //конвертируем строку в правильный формат
        {
            try //на всякий случай
            {
                // Разделение строки на две части
                int middle = line.Length / 2;
                string part1 = line.Substring(0, middle);
                string part2 = line.Substring(middle);

                // Объединение частей и сортировка
                char[] part1CharArray = part1.ToCharArray();
                char[] part2CharArray = part2.ToCharArray();

                // Создание минимальной лексикографической строки
                string result;
                if (part1CharArray[0] < part2CharArray[0])
                    result = part1 + part2;
                else
                    result = part2 + part1;

                return result;
            }
            catch
            {
                throw new Exception("Строка имела неверный формат");
            }
        }
    }
}
