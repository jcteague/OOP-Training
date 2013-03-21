using NUnit.Framework;
using OOP_Training;

namespace Tests.FileImportServiceSpecs
{
    [TestFixture]
    public class FileImporterFactorySpecs
    {
        private IFileImporterFactory sut;
        [SetUp]
        public void SetUp()
        {
            sut = new FileImporterFactory();
        }

        [Test]
        public void should_return_the_csv_importer_when_filename_ends_with_csv()
        {
            var importer = sut.GetFileImporterFor("import.csv");
            importer.
        }
    }
}