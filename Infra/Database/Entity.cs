using System;

namespace CS201_WebApi.Infra.Database
{
    public class Entity
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
