using System.IO;
using System.Xml;
using System.Xml.Serialization;
using CsvHelper;

namespace OOP_Training.FileImporter
{
    public class ProceduralActorImporter
    {
        public void ImportFile(string filename)
        {
            var actor_repository = new ActorRepository();
            if (filename.EndsWith("csv"))
            {
                 
                var stream = new StreamReader(filename);
                var csv_reader = new CsvReader(stream);
                while (csv_reader.Read())
                {
                   var actor =  csv_reader.GetRecord<Actor>();
                   actor_repository.Save(actor);
                }
                
                
            }
            if (filename.EndsWith("xml"))
            {
                var stream = new StreamReader(filename);
                var serializer = new XmlSerializer(typeof(Actor));
                var actors = (Actor[])serializer.Deserialize(stream);
                foreach (var actor in actors)
                {
                    actor_repository.Save(actor);
                }

            }
        } 
    }

    public interface IActorRepository
    {
        void Save(Actor actor);
    }

    public class ActorRepository : IActorRepository
    {
        public void Save(Actor actor)
        {
            
        }
    }
}