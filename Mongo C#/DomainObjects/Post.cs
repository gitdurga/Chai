using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace DomainObjects
{
    public class Post
    {
        public ObjectId Id { get; private set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int CharCount { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
