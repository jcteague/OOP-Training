namespace OOP_Training.FileImporter
{
    public interface IFileImporterServices
    {
        void ImportActors(string filename);

    }
    public class FileImporterWithFactory : IFileImporterServices
    {
        private readonly IActorRepository repository;
        private readonly IFileImporterFactory importer_factory;

        public FileImporterWithFactory(IActorRepository repository, IFileImporterFactory importerFactory)
        {
            this.repository = repository;
            importer_factory = importerFactory;
        }

        public void ImportActors(string filename)
        {
            var importer = importer_factory.GetFileImporterFor(filename);

            var actors = importer.ProcessFile(filename);
            foreach (var actor in actors)
            {
                repository.Save(actor);
            }
        }
    }

}