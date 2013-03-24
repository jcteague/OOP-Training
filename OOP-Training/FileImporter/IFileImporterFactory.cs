using System;
using OOP_Training.FileImporter;

namespace OOP_Training
{
    public interface IFileImporterFactory
    {
        IActorFileImporter GetFileImporterFor(string filename);
    }
    public class FileImporterFactory : IFileImporterFactory
    {
        public IActorFileImporter GetFileImporterFor(string filename)
        {
            if (filename.EndsWith("csv"))
            {
                return new CSVFileActorImporter();
            }
            if (filename.EndsWith("xml"))
            {
                return new XmlFileActorImporter();
            }
            throw new NotSupportedException("Invalid File Type");
        }
    }


}