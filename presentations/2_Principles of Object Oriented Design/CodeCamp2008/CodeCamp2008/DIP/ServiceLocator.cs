using System;

namespace CodeCamp2008.DIP
{
    public class ServiceLocator
    {
        public static object GetInstanceOf(Type type)
        {
            if (type == typeof(IFileRepository))
                return new InMemoryRepository();

            throw new InvalidOperationException();
        }
    }
}