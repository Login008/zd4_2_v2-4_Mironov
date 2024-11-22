using ClassLib;

namespace Tests
{
    [TestClass]
    public class ParamsTests
    {
        //������������ ������ ConvertToParams(string link)
        [TestMethod]
        public void TestConvertToParamsEmpty() //�������� �� ������ ����
        {
            var result = ParamsOfRequest.ConvertToParams("");
            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void TestConvertToParamsRight() //�������� �� ���������� ����
        {
            var result = ParamsOfRequest.ConvertToParams("ivanov.ivan.ivanovich.ru?id=123&action=run&value=1");
            Assert.AreEqual("action : run\nid : 123\nvalue : 1\n", result);
        }
        [TestMethod]
        public void TestConvertToParamsLessParams() //�������� �� ���� ������ ��� ����������
        {
            var result = ParamsOfRequest.ConvertToParams("ivanov.ivan.ivanovich.ru");
            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void TestConvertToParamsLessQuest() //�������� �� ���� ������ ��� ����� ?
        {
            var result = ParamsOfRequest.ConvertToParams("ivanov.ivan.ivanovich.ruid=123&action=run&value=1");
            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void TestConvertToParamsWrong1() //�������� �� ������������ ���� ��� �������� ���������
        {
            var result = Assert.ThrowsException<Exception>(() => ParamsOfRequest.ConvertToParams("ivanov.ivan.ivanovich.ru?id=&action=run&value=1"));
            Assert.AreEqual("������ ����� �������� ������", result.Message);
        }
        [TestMethod]
        public void TestConvertToParamsWrong2() //�������� �� ������������ ���� ��� ����� =
        {
            var result = Assert.ThrowsException<Exception>(() => ParamsOfRequest.ConvertToParams("ivanov.ivan.ivanovich.ru?id123&action=run&value=1"));
            Assert.AreEqual("������ ����� �������� ������", result.Message);
        }
        [TestMethod]
        public void TestConvertToParamsWrong3() //�������� �� ������������ ���� ��� ����� & ��� ���������� ����������
        {
            var result = Assert.ThrowsException<Exception>(() => ParamsOfRequest.ConvertToParams("ivanov.ivan.ivanovich.ru?id=123&action=runvalue=1"));
            Assert.AreEqual("������ ����� �������� ������", result.Message);
        }
        [TestMethod]
        public void TestConvertToParamsWrong4() //�������� �� ���� ��� ������ �� ��� ���� ����� ��������� ����������
        {
            var result = Assert.ThrowsException<Exception>(() => ParamsOfRequest.ConvertToParams("?id=123&action=run&value=1"));
            Assert.AreEqual("������ ����� �������� ������", result.Message);
        }
        [TestMethod]
        public void TestConvertToParamsWrong5() //�������� �� ������������ ���� ��� �������� ���������
        {
            var result = Assert.ThrowsException<Exception>(() => ParamsOfRequest.ConvertToParams("ivanov.ivan.ivanovich.ru?id=123&=run&value=1"));
            Assert.AreEqual("������ ����� �������� ������", result.Message);
        }



        //������������ ������ Reading(string fileName)
        [TestMethod]
        public void TestReadingRight() //�������� �� ���������� ����
        {
            var result = ParamsOfRequest.Reading("input.txt");
            Assert.AreEqual("ivanov.ivan.ivanovich.ru?id=123&action=run&value=1", result);
        }
        [TestMethod]
        public void TestReadingWrong1() //�������� �� ���� ����� ��������������� �����
        {
            var result = Assert.ThrowsException<Exception>(() => ParamsOfRequest.Reading(""));
            Assert.AreEqual("����� ���� � ������� �����������", result.Message);
        }
        [TestMethod]
        public void TestReadingWrong2() //�������� �� ���� ����� ����� � ������ ����������
        {
            var result = Assert.ThrowsException<Exception>(() => ParamsOfRequest.Reading("input1.txt"));
            Assert.AreEqual("���� ���� ��� ����������� ������ ������", result.Message);
        }
        [TestMethod]
        public void TestReadingWrong3() //�������� �� ���������� ������ ����� � �����, ��� 1 �������
        {
            var result = ParamsOfRequest.Reading("input2.txt");
            Assert.AreEqual("ivanov.ivan.ivanovich.ru?id=123&action=run&value=1", result);
        }



        //������������ ������ SaveParams(string param)
        [TestMethod]
        public void TestSaveParamsRight() //�������� �� ���������� ����
        {
            string expected = "NotNull";
            ParamsOfRequest.SaveParams(expected);
            var result = ParamsOfRequest.Reading("output.txt");

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestSaveParamsEmpty() //�������� �� ������ ����
        {
            ParamsOfRequest.SaveParams("");
            var result = ParamsOfRequest.Reading("output.txt");

            Assert.AreEqual("NULL", result);
        }
    }
}