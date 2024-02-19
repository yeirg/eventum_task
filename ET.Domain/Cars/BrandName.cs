using ET.BuildingBlocks.Domain;

namespace ET.Domain.Cars;

public class BrandName : ValueObject
{
    private readonly string _value;
    
    private BrandName()
    {
    }
    
    public BrandName(string value)
    {
        _value = value;
    }
    
    public string Value
    {
        get => _value;
        private init
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                // TODO: throw custom exception
                //throw Errors.Administration.Validation.EmptyBrandName.New();
            }
            _value = value;
        }
    }
    
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield break;
    }
    
    public static implicit operator string(BrandName brandName) => brandName.Value;
    public static implicit operator BrandName(string brandName) => new BrandName(brandName);
}