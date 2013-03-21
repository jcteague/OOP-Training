using System.Collections.Generic;
using System.IO;
using FizzWare.NBuilder;
using NUnit.Framework;
using Ninject;
using Ninject.MockingKernel.RhinoMock;
using OOP_Training;
using OOP_Training.FileImporter;
using Rhino.Mocks;
using System.Linq;

namespace Tests.FileImportServiceSpecs
{
    
    public class AutoMockSpec<TInterface, TImpl> where TImpl : TInterface
    {
        protected readonly RhinoMocksMockingKernel kernel;

        [SetUp]
        public void SetUp()
        {
            kernel.Reset();
        }
        public AutoMockSpec()
        {
            this.kernel = new RhinoMocksMockingKernel();
            kernel.Bind<TInterface>().To<TImpl>();
        }
        protected TInterface sut { get { return kernel.Get<TInterface>(); } }
//        protected T GetMock<T>()
//        {
//           
//        }
    }
    public class FileImporterWithFactorySpecs : AutoMockSpec<IFileImporterServices, FileImporterWithFactory>
    {
        private IEnumerable<Actor> actors;

        [SetUp]
        public void SetUp()
        {
            actors = Builder<Actor>.CreateListOfSize(2).Build();
            var stubbed_file_impoerter = kernel.Get<IActorFileImporter>();
            stubbed_file_impoerter.Stub(x => x.ProcessFile(Arg<string>.Is.Anything)).Return(actors);
            kernel.Get<IFileImporterFactory>()
                  .Stub(x => x.GetFileImporterFor(Arg<string>.Is.Anything))
                  .Return(stubbed_file_impoerter);
            
        }

        [Test]
        public void should_save_records_from_file()
        {
            sut.ImportActors("file");
            kernel.Get<IActorRepository>().Stub(x => x.Save(actors.ToArray()[0])).Repeat.Once();
            kernel.Get<IActorRepository>().Stub(x => x.Save(actors.ToArray()[1])).Repeat.Once();
        }
        
    }
}