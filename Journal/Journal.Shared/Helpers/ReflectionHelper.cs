namespace Journal.Shared.Helpers
{
    public static class ReflectionHelper
    {
        public static string AssemblySearchPrefix = "Journal";

        public static List<ClassWithAttribute<TAttribute>> GetClassesWithAttribute<TBaseClass, TAttribute>()
            where TAttribute : Attribute
        {
            return GetClassesWithAttribute<TAttribute>(typeof(TBaseClass));
        }

        public static List<ClassWithAttribute<TAttribute>> GetClassesWithAttribute<TAttribute>(Type baseClass)
            where TAttribute : Attribute
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.FullName != null)
                .Where(x => x.FullName!.ToString().StartsWith(AssemblySearchPrefix));

            var retClasses = new List<ClassWithAttribute<TAttribute>>();

            foreach (var assembly in assemblies)
            {
                var assemblyTypes = assembly.GetTypes().Where(x =>
                    x.BaseType?.Name == baseClass.Name ||
                    x.BaseType?.BaseType?.Name == baseClass.Name ||
                    x.BaseType?.BaseType?.BaseType?.Name == baseClass.Name ||
                    (x.IsSubclassOf(baseClass))
                ).ToList();

                if (assemblyTypes.Count == 0)
                {
                    assemblyTypes = assembly.GetTypes()
                        .Where(x => x.BaseType != null)
                        .Where(x => x.BaseType!.Name.StartsWith(baseClass.Name + "`")).ToList();
                }

                foreach (var classType in assemblyTypes)
                {
                    var serviceAttributes = classType.GetCustomAttributes(typeof(TAttribute), true).ToList();
                    if (serviceAttributes.Count > 0)
                    {
                        var newClass = new ClassWithAttribute<TAttribute>
                        {
                            ClassType = classType,
                            Attributes = serviceAttributes.Select(x => (TAttribute)x).ToList()
                        };
                        retClasses.Add(newClass);
                    }
                }
            }

            return retClasses;
        }

        public class ClassWithAttribute<TAttribute>
        {
            public Type? ClassType { get; set; }

            public List<TAttribute> Attributes { get; set; } = new();

            public TAttribute Attribute => Attributes.FirstOrDefault()!;
        }
    }
}

