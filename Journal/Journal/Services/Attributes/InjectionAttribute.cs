namespace Journal.Services.Attributes
{
    public enum InjectionType
    {
        Singleton,
        Scoped,
        Transient
    }

    public class InjectionAttribute(InjectionType injectionType) : Attribute
    {
        public InjectionType InjectionType { get; set; } = injectionType;
    }
}
