using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;


namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator:AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                   .WithMessage("Lütfen ürün adını boş geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(3)
                    .WithMessage("Lütfen ürün adını 3 ile 150 karakter giriniz.");
            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen stock sayısını boş geşmeyiniz.")
                .Must(s => s >= 0)//stock bilgisi 0 dan büyük ya da eşit olabilir
                    .WithMessage("Stock sayısı 0 dan küçük olamaz!");
            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen fiyat bilgisini boş geşmeyiniz.")
                .Must(p => p >= 0)//stock bilgisi 0 dan büyük ya da eşit olabilir
                    .WithMessage("Fiyatı 0 dan küçük olamaz!");

        }

    }
}
