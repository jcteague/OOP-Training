using System.Collections.Generic;

namespace OOP_Training.FileImporter
{
    public interface IActorFileImporter
    {
        IEnumerable<Actor> ProcessFile(string filename);
    }

    public class CSVFileActorImporter : IActorFileImporter
    {
        public IEnumerable<Actor> ProcessFile(string filename)
        {
            throw new System.NotImplementedException();
        }
    }
    public class XmlFileActorImporter : IActorFileImporter
    {
        public IEnumerable<Actor> ProcessFile(string filename)
        {
            throw new System.NotImplementedException();
        }
    }
}