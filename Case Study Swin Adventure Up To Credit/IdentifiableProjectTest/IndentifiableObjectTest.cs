using NUnit.Framework;
//using IdentifiableObject;

namespace IdentifiableObject
{
    public class IdentifiableProjectTests
    {
        private IdentifiableObject testObject;
        private IdentifiableObject testlbject2;
        [SetUp]
        public void Setup()
        {
            testObject = new IdentifiableObject(new string[] { "Test1", "Test2" });
            testlbject2 = new IdentifiableObject(new string[] { "" });
        }

        [Test]
        public void TestAreYou()
        {
            //string[] testStringArray = new string[] { "Test", "CheckOrder" };
            //IdentifiableObject testObject = new IdentifiableObject(new string[] { "Test1", "Test2" });
            Assert.IsTrue(testObject.AreYou("Test1"));
        }
        [Test]
        public void TestNotAreYou()
        {
            //IdentifiableObject testObject = new IdentifiableObject(new string[] { "Test1", "Test2" });
            Assert.IsFalse(testObject.AreYou("Test3"));
        }
        [Test]
        public void TestCaseSensitive()
        {
            //IdentifiableObject testObject = new IdentifiableObject(new string[] { "Test1", "Test2" });
            Assert.IsTrue(testObject.AreYou("test1"));
        }
        [Test]
        public void TestFistNoId()
        {
            StringAssert.AreEqualIgnoringCase("", testlbject2.FirstId);
        }
        [Test]

        public void TestFirstID()
        {
            //IdentifiableObject testObject = new IdentifiableObject(new string[] { "Test1", "Test2" });
            //IdentifiableObject testObject = new IdentifiableObject(testStringArray);
            // StringAssert.AreEqualIgnoringCase("Test", testObject.FirstId);
            StringAssert.AreEqualIgnoringCase("Test1", testObject.FirstId);
        }
        [Test]
        public void TestAddId()
        {
            //IdentifiableObject testObject = new IdentifiableObject(new string[] { "Test1", "Test2" });
            testObject.AddIdentifier("Test3");
            Assert.IsTrue(testObject.AreYou("Test3"));
        }

    }
}