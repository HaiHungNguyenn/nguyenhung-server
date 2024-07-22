using System.Collections;

namespace NguyenHung.DAL.Dtos;

public class DtoProduct
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Ingredient { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid CategoryId {get;set;}
    public string CategoryName { get; set; } = string.Empty;
    public string FishImage { get; set; } = string.Empty;
    public int SizeType { get; set; }
    public ICollection<DtoNutrient> Nutrients { get; set; } = new List<DtoNutrient>();
    public ICollection<DtoBenefit> Benefits { get; set; } = new List<DtoBenefit>();
    public ICollection<DtoProductImage> ProductImages { get; set; } = new List<DtoProductImage>();
}

public class DtoNutrient{
    public required string Name { get; set; }
    public float Weight { get; set; }
    public float Percentage { get; set; }
}

public class DtoBenefit
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public string BenefitImage { get; set; } = "https://nguyenhung.blob.core.windows.net/nguyenhungstorage/eye.png";
}

public class DtoProductImage
{
    public Guid Id { get; set; }
    public required string ImageUrl { get; set; }
}