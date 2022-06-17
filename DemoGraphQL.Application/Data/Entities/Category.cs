﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DemoGraphQL.Application.Data.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Description { get; set; }
    }
}
