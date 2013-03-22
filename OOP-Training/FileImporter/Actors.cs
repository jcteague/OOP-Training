using System;
using System.Collections.Generic;

namespace OOP_Training.FileImporter
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
         
    }
    public class Movie
    {
        private List<Actor> actors;

        public Movie()
        {
            this.actors = new List<Actor>();
        }

        protected IEnumerable<Actor> Actors
        {
            get { return actors; }
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int YearMade { get; set; }
        

        public void AddActor(Actor actor)
        {
            this.actors.Add(actor);
        }
    }
}