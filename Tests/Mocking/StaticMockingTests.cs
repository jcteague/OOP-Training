using NUnit.Framework;
using OOP_Training.FileImporter;

namespace Tests.Mocking
{
    public class RepositoryConsumer
    {
        private readonly IActorRepository actor_repository;

        public RepositoryConsumer(IActorRepository actorRepository)
        {
            actor_repository = actorRepository;
        }

        public void AddActor(Actor actor)
        {
            actor_repository.Save(actor);
        }
        public Actor AddActorToMovie(Movie movie, int actorId)
        {
            var actor = actor_repository.Get(actorId);
            movie.AddActor(actor);
        }
    }
    [TestFixture]
    public class StaticMockingTests
    {
         //test actor repository save method was called
        
        [SetUp]
        public void SetUp()
        {
            //create consumer with static mock
        }

        // verify the save method was called

        
    }
}