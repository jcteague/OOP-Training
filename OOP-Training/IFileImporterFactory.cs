namespace OOP_Training
{
    public interface IFileImporterFactory
    {
        IActorFileImporter GetFileImporterFor(string filename);
    }
}