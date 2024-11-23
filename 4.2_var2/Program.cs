using ClassLib;

Console.Write("Введите название входного файла: ");
string fileName = Console.ReadLine();

if (DataFailureClass.IsFileExisting(fileName) && File.Exists(fileName))
{
    // Чтение входной строки
    StreamReader sr = File.OpenText(fileName);
    string line = sr.ReadLine();
    sr.Close();

    if (!string.IsNullOrEmpty(line))
    {
        if (DataFailureClass.IsCorrectlLength(line))
        {
            if (DataFailureClass.IsLetterAndUpper(line))
            {
                if (DataFailureClass.IsRepeating(line))
                {
                    string result = DataFailureClass.Converting(line);

                    // Вывод результата
                    StreamWriter sw = File.CreateText("output.txt");
                    sw.WriteLine(result);
                    sw.Close();

                    Console.WriteLine("Задача выполнена");
                }
                else
                    Console.WriteLine("Все символы в строке должны быть уникальны");
            }
            else
                Console.WriteLine("Все символы в строке должны быть в верхнем регистре и являться буквами");
        }
        else
            Console.WriteLine("Длина строки не входит в диапозон от 1 до 26");
    }
    else
        Console.WriteLine("Первая строка в файле отсутствует");
}
else
    Console.WriteLine("Или файл называется не input.txt, или его нет в корневой папке");
