using System.Collections.Generic;
using System.IO;
using OOP_Training.FileImporter;

namespace OOP_Training
{
    public interface IActorFileImporter
    {
        IEnumerable<Actor> ProcessFile(string filename);
    }
}