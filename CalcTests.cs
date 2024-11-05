using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Programm
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Sum_10plus20_return30()
        {
            //Arrange
            int x = 10;
            int y = 20;
            int excpected = 30;

            //Act
            int actual = Calc.Sum(x, y);

            //Assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void Minus_40minus5_return35()
        {
            //Arrange
            int x = 40;
            int y = 5;
            int excpected = 35;

            //Act
            int actual = Calc.Minus(x, y);

            //Assert
            Assert.AreEqual(excpected, actual);
        }
    }

    [TestClass]
    public class ItemTest
    {
        Items<string> actual = new Items<string>();

        //Запускается при каждом начале метода-теста
        [TestInitialize]
        public void Init()
        {
            actual.Add("Bread");
            actual.Add("Milk");
            actual.Add("Beer");
        }

        //Запускается при каждом окончании метода-теста
        [TestCleanup]
        public void Cleanup()
        {
            actual.Clear();
        }

        [TestMethod]
        public void Add_AddItem_Equals()
        {
            //Arrange
            Items<string> expected = new Items<string>(new List<string>() { "Bread", "Milk", "Beer" });

            //Act
            bool flag = true;
            if (expected.Count() != actual.Count())
                flag = false;
            for (int i = 0; i < expected.Count(); i++)
            {
                if (expected[i] != actual[i])
                    flag = false;
            }

            //Assert
            Assert.IsTrue(flag);
        }
    }

    [TestClass]
    public class PeopleTest
    {
        static People people1 = new People();
        //Запускается единственный раз при первом запуске метода-теста, в параметрах требуется TestContext
        [ClassInitialize]
        public static void InitClass(TestContext context)
        {
            people1.ReName("John");
            people1.ReAge(19);
        }

        [ClassCleanup]
        //Запускается единственный раз при завершении последнего метода-теста
        public static void ClearClass()
        {
            people1.ClearPeople();
        }

        [TestMethod]
        public void SameName_JohnEqualJohn_true()
        {
            //Arrange
            var John = new People("John", 25);
            //Act
            bool flag = John.SameName(people1);

            //Assert
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void SameAge_19Equal19_true()
        {
            //Arrange
            var Marry = new People("Marry", 19);
            //Act
            bool flag = Marry.SameAge(people1);

            //Assert
            Assert.IsTrue(flag);
        }

        //На таком маленьком примере не придумал куда пихнуть

        //Срабатывает при первом запуске любого метода-теста любого класса единственный раз, в параметрах требуется TestContext
        [AssemblyInitialize]
        public static void AssInit(TestContext context) { }

        //Срабатывает при последнем запуске любого метода-теста любого класса единственный раз
        [AssemblyCleanup]
        public static void AssCleanup() { }
    }
}