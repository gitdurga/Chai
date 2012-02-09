using DomainObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MongDB.UnitTests
{


    /// <summary>
    ///This is a test class for PostRepositoryTest and is intended
    ///to contain all PostRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PostRepositoryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for AddPost
        ///</summary>
        [TestMethod()]
        public void AddPostTest()
        {
            PostRepository target = new PostRepository();
            Random rand = new Random();
            string title = String.Format("Title{0}",rand.Next(1,10000));
            var post = new Post()
            {
                Title = title,
                Body = "This isn't a very long post.",
                CharCount = 27,
                Comments = new List<Comment>
                    {
                        { new Comment() { TimePosted = new DateTime(2010,1,1), 
                                          Email = "bob_mcbob@gmail.com", 
                                          Body = "This article is too short!" } },
                        { new Comment() { TimePosted = new DateTime(2010,1,2), 
                                          Email = "Jane.McJane@gmail.com", 
                                          Body = "I agree with Bob." } }
                    }
            };
            target.AddPost(post);
            Post postFromDb = target.GetPost(title);
            Assert.IsTrue(post.Id == postFromDb.Id);
        }
    }
}
