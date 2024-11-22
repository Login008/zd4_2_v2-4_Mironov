using ClassLib;

namespace Tests
{
    [TestClass]
    public class ParamsTests
    {
        //Тестирование метода ConvertToParams(string link)
        [TestMethod]
        public void TestConvertToParamsEmpty() //Проверка на пустой ввод
        {
            var result = ParamsOfRequest.ConvertToParams("");
            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void TestConvertToParamsRight() //Проверка на правильный ввод
        {
            var result = ParamsOfRequest.ConvertToParams("ivanov.ivan.ivanovich.ru?id=123&action=run&value=1");
            Assert.AreEqual("action : run\nid : 123\nvalue : 1\n", result);
        }
        [TestMethod]
        public void TestConvertToParamsLessParams() //Проверка на ввод ссылки без параметров
        {
            var result = ParamsOfRequest.ConvertToParams("ivanov.ivan.ivanovich.ru");
            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void TestConvertToParamsLessQuest() //Проверка на ввод ссылки без знака ?
        {
            var result = ParamsOfRequest.ConvertToParams("ivanov.ivan.ivanovich.ruid=123&action=run&value=1");
            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void TestConvertToParamsWrong1() //Проверка на неправильный ввод без значения параметра
        {
            var result = Assert.ThrowsException<Exception>(() => ParamsOfRequest.ConvertToParams("ivanov.ivan.ivanovich.ru?id=&action=run&value=1"));
            Assert.AreEqual("Ссылка имела неверный формат", result.Message);
        }
        [TestMethod]
        public void TestConvertToParamsWrong2() //Проверка на неправильный ввод без знака =
        {
            var result = Assert.ThrowsException<Exception>(() => ParamsOfRequest.ConvertToParams("ivanov.ivan.ivanovich.ru?id123&action=run&value=1"));
            Assert.AreEqual("Ссылка имела неверный формат", result.Message);
        }
        [TestMethod]
        public void TestConvertToParamsWrong3() //Проверка на неправильный ввод без знака & для разделения параметров
        {
            var result = Assert.ThrowsException<Exception>(() => ParamsOfRequest.ConvertToParams("ivanov.ivan.ivanovich.ru?id=123&action=runvalue=1"));
            Assert.AreEqual("Ссылка имела неверный формат", result.Message);
        }
        [TestMethod]
        public void TestConvertToParamsWrong4() //Проверка на ввод без ссылки на сам сайт перед описанием параметров
        {
            var result = Assert.ThrowsException<Exception>(() => ParamsOfRequest.ConvertToParams("?id=123&action=run&value=1"));
            Assert.AreEqual("Ссылка имела неверный формат", result.Message);
        }
        [TestMethod]
        public void TestConvertToParamsWrong5() //Проверка на неправильный ввод без названия параметра
        {
            var result = Assert.ThrowsException<Exception>(() => ParamsOfRequest.ConvertToParams("ivanov.ivan.ivanovich.ru?id=123&=run&value=1"));
            Assert.AreEqual("Ссылка имела неверный формат", result.Message);
        }



        //Тестирование метода Reading(string fileName)
        [TestMethod]
        public void TestReadingRight() //Проверка на правильный ввод
        {
            var result = ParamsOfRequest.Reading("input.txt");
            Assert.AreEqual("ivanov.ivan.ivanovich.ru?id=123&action=run&value=1", result);
        }
        [TestMethod]
        public void TestReadingWrong1() //Проверка на ввод имени несуществующего файла
        {
            var result = Assert.ThrowsException<Exception>(() => ParamsOfRequest.Reading(""));
            Assert.AreEqual("Такой файл с ссылкой отсутствует", result.Message);
        }
        [TestMethod]
        public void TestReadingWrong2() //Проверка на ввод имени файла с пустым содержимым
        {
            var result = Assert.ThrowsException<Exception>(() => ParamsOfRequest.Reading("input1.txt"));
            Assert.AreEqual("Файл пуст или отсутствует первая строка", result.Message);
        }
        [TestMethod]
        public void TestReadingWrong3() //Проверка на считывание данных файла с более, чем 1 строкой
        {
            var result = ParamsOfRequest.Reading("input2.txt");
            Assert.AreEqual("ivanov.ivan.ivanovich.ru?id=123&action=run&value=1", result);
        }



        //Тестирование метода SaveParams(string param)
        [TestMethod]
        public void TestSaveParamsRight() //Проверка на правильный ввод
        {
            string expected = "NotNull";
            ParamsOfRequest.SaveParams(expected);
            var result = ParamsOfRequest.Reading("output.txt");

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestSaveParamsEmpty() //Проверка на пустой ввод
        {
            ParamsOfRequest.SaveParams("");
            var result = ParamsOfRequest.Reading("output.txt");

            Assert.AreEqual("NULL", result);
        }
    }
}