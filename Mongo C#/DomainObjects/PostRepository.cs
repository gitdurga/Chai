using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace DomainObjects
{
    public class PostRepository
    {
        public PostRepository()
        {
        }

        public void AddPost(Post post)
        {
            string connectionString = "mongodb://localhost:27017,localhost:27018,localhost:27019";
            MongoServer server = MongoServer.Create(connectionString);
            var database = server.GetDatabase(DBSettings.DatabaseName);
            var collection = database.GetCollection<Post>("post");

            //drop collection
            //collection.Drop();
            collection.Save(post);
        }

        public Post GetPost(string title)
        {
            string connectionString = "mongodb://localhost";
            MongoServer server = MongoServer.Create(connectionString);
            var database = server.GetDatabase(DBSettings.DatabaseName);
            var collection = database.GetCollection<Post>("post");
            var query = Query.Matches("Title", title);

            return collection.FindOne(query);

        }
    }
}
