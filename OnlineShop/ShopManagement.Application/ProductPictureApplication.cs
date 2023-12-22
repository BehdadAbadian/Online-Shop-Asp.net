using _0_Framework.Application;
using _00_Framework.Application;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;


namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository, IProductRepository productRepository, IFileUploader fileUploader)
        {
            _productPictureRepository = productPictureRepository;
            _productRepository = productRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProductPicture command)
        {
           var operation = new OperationResult();
            //if (_productPictureRepository.Exists(x => x.Picture == command.Picture && x.ProductId == command.ProductId))
            //    return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var product = _productRepository.GetProductWithCategory(command.ProductId);
            var path = $"{product.Category.Slug}/{product.Slug}";
            var picturePath = _fileUploader.Upload(command.Picture, path);

            var produtPiture = new ProductPicture(command.ProductId, picturePath, command.PictureAlt,command.PictureTitle);
            _productPictureRepository.Create(produtPiture);
            _productPictureRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();
            var productPiture = _productPictureRepository.GetWithProductAndCategory(command.Id);
            if (productPiture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);


            //if (_productPictureRepository.Exists(x => x.Picture == command.Picture && x.ProductId == command.ProductId && x.Id != command.Id))
            //    return operation.Failed(ApplicationMessages.DuplicatedRecord);

           
            var path = $"{productPiture.Product.Category.Slug}//{productPiture.Product.Slug}";
            var picturePath = _fileUploader.Upload(command.Picture, path);

            productPiture.Edit(command.ProductId, picturePath, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.SaveChanges();
            return operation.Succedded(); 
        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var productPiture = _productPictureRepository.Get(id);
            if (productPiture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
           
            productPiture.Remove();
            _productPictureRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var productPiture = _productPictureRepository.Get(id);
            if (productPiture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            productPiture.Restore();
            _productPictureRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _productPictureRepository.Search(searchModel);
        }
    }
}
