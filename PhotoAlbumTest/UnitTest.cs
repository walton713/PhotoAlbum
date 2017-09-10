using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PhotoAlbum;

namespace PhotoAlbumTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Get_Album_With_Good_ID()
        {
            int id = 3;
            Album al = new Album();
            Dictionary<int, string> photos = al.GetAlbumContents(id.ToString());
            Assert.AreNotEqual(0, photos.Count);
        }

        [TestMethod]
        public void Get_Album_With_Bad_ID()
        {
            int id = 500;
            Album al = new Album();
            Dictionary<int, string> photos = al.GetAlbumContents(id.ToString());
            Assert.AreEqual(0, photos.Count);
        }
    }
}
