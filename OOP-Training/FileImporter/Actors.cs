using System;

namespace OOP_Training.FileImporter
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
         
    }
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearMade { get; set; }
    }
}