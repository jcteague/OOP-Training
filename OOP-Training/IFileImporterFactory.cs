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
            throw new System.NotImplementedException();
        }
    }
}