using ClassLib;

// See https://aka.ms/new-console-template for more information

//Вариант 4 из файла text.html
string link = ParamsOfRequest.Reading("input.txt");
string param = ParamsOfRequest.ConvertToParams(link);
ParamsOfRequest.SaveParams(param);
Console.WriteLine("Задача выполнена");
