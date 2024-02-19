using ET.BuildingBlocks.Domain;

namespace ET.Domain.CarColors;

public class Color : ValueObject
{
    private readonly string _value;

    private Color()
    {
    }
    
    public Color(string value)
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
                //throw Errors.Administration.Validation.EmptyCarColor.New();
            }
            _value = value;
        }
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator string(Color color) => color.Value;
    public static implicit operator Color(string color) => new Color(color);
}