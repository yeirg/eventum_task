namespace ET.Domain.Cars;

public class ModelName
{
    private readonly string _value;
    
    private ModelName()
    {
    }
    
    public ModelName(string value)
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
                //throw Errors.Administration.Validation.EmptyModelName.New();
            }
            _value = value;
        }
    }
    
    public static implicit operator string(ModelName modelName) => modelName.Value;
    public static implicit operator ModelName(string modelName) => new ModelName(modelName);
}