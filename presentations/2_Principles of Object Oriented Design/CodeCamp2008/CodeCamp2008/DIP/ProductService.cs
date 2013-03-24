using System;
using System.Collections.Generic;

namespace CodeCamp2008.DIP
{
    public class ProductService
    {
        

        
        public IEnumerable<Product> GetProductByCategory(string category)
        {
            IFileRepository repository = new FileRepository();
            IEnumerable<Product> allProducts = repository.GetAllProduct();
            foreach (Product product in allProducts)
            {
                if (product.Category == category)
                    yield return product;
            }
        }
    }
    

    pubic class ProductService_ISP{
        private IFileRepository _repository;
        public ProductService()
        {
            _repository = (IFileRepository) ServiceLocator.GetInstanceOf(typeof(IFileRepository));
        }

        public IEnumerable<Product> GetProductByCategory(string category)
        {
            IEnumerable<Product> allProducts = _repository.GetAllProduct();
            foreach (Product product in allProducts)
            {
                if (product.Category == category)
                    yield return product;
            }
        }
    }
}