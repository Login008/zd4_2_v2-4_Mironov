using System.Runtime.CompilerServices;

namespace ClassLib
{
    static public class ParamsOfRequest
    {
        static public string Reading(string fileName) //метод чтения содержимого из файла по имени файла
        {
            if (File.Exists(fileName)) //проверяем, существует ли такой файла
            {
                StreamReader sr = File.OpenText(fileName); //открываем поток
                string link = sr.ReadLine(); //считываем только первую строку в переменную link
                sr.Close(); //закрываем поток

                if (!string.IsNullOrEmpty(link)) //Проверяем, была ли в файле первая строка
                    return link;
                else
                    throw new Exception("Файл пуст или отсутствует первая строка");
            }
            else
                throw new Exception("Такой файл с ссылкой отсутствует");
        }

        static public string ConvertToParams(string link)
        {
            try //На все случаи сразу
            {
                int index = -1;

                for (int i = 0; i < link.Length; i++)
                {
                    if (link[i] == '?') //Ищем в ссылке начало описания параметров
                    {
                        if (i == 0)
                            throw new Exception(); //Проверка на наличие самой ссылки до начала описания параметров
                        index = i + 1; 
                        break;
                    }
                }
                if (index != -1) //проверка на наличие параметров в ссылке
                {
                    List<string> list = new List<string>();

                    while (index < link.Length) 
                    {
                        if (link[index] == '=') //проверка на наличие названия параметра
                            throw new Exception();

                        string param = "";

                        while (link[index] != '=')
                        {
                            if (link[index] == '&') //проверка на наличие знака разделения параметров
                                throw new Exception();

                            param += link[index]; //добавляем в переменную название параметра
                            index++;
                        }

                        index++;
                        param += " : ";

                        if (link[index] == '&') //проверка на наличие значения параметра
                            throw new Exception();

                        while (link[index] != '&')
                        {
                            if (link[index] == '=') //проверка
                                throw new Exception();

                            param += link[index]; //добавляем значение параметра
                            index++;

                            if (index == link.Length) //для избегания выхода за предел длины строки
                                break;
                        }

                        index++;
                        list.Add(param); //добавляем параметр в список
                    }
                    list.Sort(); //итоговая сортировка параметров по названию по алфавиту

                    string param1 = "";
                    foreach (var item in list)
                    {
                        param1 += item + "\n"; //заносим все параметры в одну переменную
                    }
                    return param1; //возвращаем итог
                }
                else
                    return null;
            }
            catch
            {
                throw new Exception("Ссылка имела неверный формат");
            }
        }

        static public void SaveParams(string param) //метод для сохранения результата в output.txt
        {
            StreamWriter sw = File.CreateText("output.txt");
            if (!string.IsNullOrEmpty(param)) //проверка на наличие параметров
            {
                sw.WriteLine(param); //записываем результат
            }
            else
            {
                sw.WriteLine("NULL"); //Записываем NULL в output.txt, если параметров в ссылке не было
            }
            sw.Close();
        }
    }
}
