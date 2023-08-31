namespace Application.cqrs.Commands.CreateProduct
{
    public class CreateProductRequest
    {
        public Guid CatId { get; set; }
        public string Title { get; set; }


    }
}
