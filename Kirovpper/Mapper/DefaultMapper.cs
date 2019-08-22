using Kirovpper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Kirovpper.Mapper {
  public class DefaultMapper<FromType, ToType> : IMapper<FromType, ToType>
     where FromType : class, new() where ToType : class, new() {
    public virtual void GenerateMappingDictionary(IServiceProvider serviceProvider) {
      var fromProperties = typeof(FromType).GetProperties();
      var toProperties = typeof(ToType).GetProperties();
    }

    public virtual IGrouping<PropertyInfo, PropertyInfo> GenerateFromPropertyRelatedToProperties(PropertyInfo fromProperty, IEnumerable<PropertyInfo> toProperties) {

      IEnumerable<PropertyInfo> relatedProperties = null;

      var caseStyles = Config.TargetPropertyNameCaseStyles;
      bool ignoreCase = caseStyles.HasFlag(CaseStyle.IgnoreCase);
      string rawName = fromProperty.Name;
      List<string> relatedNames = new List<string>();
      relatedNames.AddRange(Config.Converters.Select(c => c.Convert(rawName)).ToList());
      relatedNames.AddRange(Config.CustomConverters.Select(c => c.Convert(rawName)).ToList());

      Func<PropertyInfo, bool> comparator = null;
      if (ignoreCase) {
        relatedNames = relatedNames.Select(name => name.ToUpperInvariant()).ToList();
        comparator = (propertyInfo) => relatedNames.Contains(propertyInfo.Name.ToUpperInvariant());
      }
      else
        comparator = (propertyInfo) => relatedNames.Contains(propertyInfo.Name);
      relatedProperties = toProperties.Where(comparator);
      return null;
    }
    public ToType Convert(FromType fromObject, IServiceProvider serviceProvider) {
      if (!Config.MappingDictionary.ContainsKey((typeof(ToType), typeof(FromType)))) {
        GenerateMappingDictionary(serviceProvider);
      }
      return null;
    }

    public IEnumerable<ToType> Convert(IEnumerable<FromType> fromObjects, IServiceProvider serviceProvider) {
      throw new NotImplementedException();
    }
  }
}
