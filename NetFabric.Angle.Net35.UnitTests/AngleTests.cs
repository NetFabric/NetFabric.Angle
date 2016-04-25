using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace NetFabric.Net35.UnitTests
{
    [TestClass]
    public class AngleTests
    {

        [TestMethod]
        public void IsSerializationDefinedCorrectly()
        {
            var angle = Angle.FromDegrees(-45.0);
            var formatter = new BinaryFormatter();
            object result;
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, angle);
                stream.Seek(0, SeekOrigin.Begin);
                result = formatter.Deserialize(stream);
            }
            Assert.AreEqual(angle, result);
        }

    }
}
