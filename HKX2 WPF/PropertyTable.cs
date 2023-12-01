using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKX2.Edits;

public interface IPropertySet
{
    System.Type PropertyType { get; }


}


public class PropertyTypeSet<T> : IPropertySet
{
    private readonly Dictionary<string, T> propertyMap = new Dictionary<string, T>();
    public System.Type PropertyType => typeof(T);

    public T GetValue(string propertyName) => propertyMap[propertyName];


}

public class PropertyTable
{
    private readonly Dictionary<string, Func<string>> intPropertyMap = new Dictionary<string, Func<string>>();

    private readonly Dictionary<System.Type, IPropertySet> propertySetMap = new Dictionary<System.Type, IPropertySet> { };

    public T GetProperty<T>(string propertyName)
    {

        var propertySet = propertySetMap[typeof(T)]; 

        var targetPropertySet = propertySet as PropertyTypeSet<T>;

        return targetPropertySet!.GetValue(propertyName);
    }

}
