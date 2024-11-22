using ClassLib;

// See https://aka.ms/new-console-template for more information

//Вариант 4 из файла text.html
try //Для отображения exceptionов
{
    Console.Write("Введите название файла с ссылкой: "); //вводим название исходного файла
    string fileName = Console.ReadLine();

    string link = ParamsOfRequest.Reading(fileName); //работа с файлом
    string param = ParamsOfRequest.ConvertToParams(link);
    ParamsOfRequest.SaveParams(param);

    Console.WriteLine("Задача выполнена");
}
catch
{
    Console.WriteLine("Ссылка имела неверный формат / файл с ссылкой был пуст / Файл отсутствует");
}
