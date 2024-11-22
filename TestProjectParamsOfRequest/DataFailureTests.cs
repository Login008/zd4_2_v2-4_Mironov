using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib;

namespace Tests
{
    [TestClass]
    public class IsFileExisting //тестирование метода IsFileExisting(string row)
    {
        [TestMethod]
        public void Correct() //Правильный ввод
        {
            Assert.AreEqual(true, DataFailureClass.IsFileExisting("input.txt"));
        }

        [TestMethod]
        public void NotCorrect()
        {
            Assert.AreEqual(false, DataFailureClass.IsFileExisting("inpqut.txt"));
        }
    }

    [TestClass]
    public class IsLetterAndUpper //тестирование метода IsLetterAndUpper(string row)
    {
        [TestMethod]
        public void Correct() //правильный ввод
        {
            Assert.AreEqual(true, DataFailureClass.IsLetterAndUpper("ASGJ"));
        }

        [TestMethod]
        public void WithNoUpper() //неправильный ввод с использованием нижнего регистра
        {
            Assert.AreEqual(false, DataFailureClass.IsLetterAndUpper("ASdGJ"));
        }


        [TestMethod]
        public void UsingNotLetter() //неправильный ввод с использованием цифры вместо буквы
        {
            Assert.AreEqual(false, DataFailureClass.IsLetterAndUpper("AS2GJ"));
        }

        [TestMethod]
        public void FirstLetterNoCorrect() //Первая буква неправильная
        {
            Assert.AreEqual(false, DataFailureClass.IsLetterAndUpper("aSGJ"));
        }

        [TestMethod]
        public void LastLetterNoCorrect() //Последняя буква неправильная
        {
            Assert.AreEqual(false, DataFailureClass.IsLetterAndUpper("ASGj"));
        }
    }

    [TestClass]
    public class IsRepeating //тестирование метода IsRepeating(string row)
    {
        [TestMethod]
        public void Correct() //правильный ввод
        {
            Assert.AreEqual(true, DataFailureClass.IsRepeating("ASGJ"));
        }

        [TestMethod]
        public void NotСorrect() //неправильный ввод
        {
            Assert.AreEqual(false, DataFailureClass.IsRepeating("ASAGJ"));
        }

        [TestMethod]
        public void NotCorrectFirstAndLastLetters() //Неправильный ввод с повторением первой и последней буквы
        {
            Assert.AreEqual(false, DataFailureClass.IsRepeating("ASGJA"));
        }

    }

    [TestClass]
    public class IsCorrectLength //тестирование метода IsCorrectLength(string row)
    {
        [TestMethod]
        public void Correct() //правильный ввод
        {
            Assert.AreEqual(true, DataFailureClass.IsCorrectlLength("ASGJ"));
        }

        [TestMethod]
        public void NotCorrectEmpty() //неправильный ввод с пустым вводом
        {
            Assert.AreEqual(false, DataFailureClass.IsCorrectlLength(""));
        }

        [TestMethod]
        public void NotCorrectMoreThanMax() //неправильный ввод с превышением верхней границы допустимой длины
        {
            Assert.AreEqual(false, DataFailureClass.IsCorrectlLength("12345678901234567890123456789"));
        }

        [TestMethod]
        public void BottomCorrect() //нижнее пограничное значение
        {
            Assert.AreEqual(true, DataFailureClass.IsCorrectlLength("A"));
        }

        [TestMethod]
        public void TopCorrect() //верхнее пограничное значение
        {
            Assert.AreEqual(true, DataFailureClass.IsCorrectlLength("12345678901234567890123456"));
        }
    }
}
