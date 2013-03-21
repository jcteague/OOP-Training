using NUnit.Framework;
using OOP_Training;
using OOP_Training.FileImporter;
using Should;

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
            importer.ShouldBeType<CSVFileActorImporter>();
        }

        [Test]
        public void should_return_xml_importer_when_filetype_is_xml()
        {
            var importer = sut.GetFileImporterFor("import.xml");
            importer.ShouldBeType<XmlFileActorImporter>();
        }
    }
}