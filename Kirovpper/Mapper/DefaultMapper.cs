using Kirovpper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kirovpper.Mapper {
  public class DefaultMapper<FromType, ToType> : IMapper<FromType, ToType>
     where FromType : class, new() where ToType : class, new() {
    public virtual async Task<IEnumerable<IGrouping<PropertyInfo, PropertyInfo>>> GetMappingInfo(IServiceProvider serviceProvider) {
      IEnumerable<IGrouping<PropertyInfo, PropertyInfo>> mappingInfo;
      if (!Config.MappingDictionary.ContainsKey((typeof(ToType), typeof(FromType)))) {
        await GenerateMappingDictionary(serviceProvider);
      }
      mappingInfo = Config.MappingDictionary[(typeof(FromType), typeof(ToType))];
      return mappingInfo;
    }
    /// <summary>
    /// 生成类型间映射关系
    /// </summary>
    /// <param name="serviceProvider"></param>
    public virtual async Task GenerateMappingDictionary(IServiceProvider serviceProvider) {
      var fromProperties = typeof(FromType).GetProperties();
      var toProperties = typeof(ToType).GetProperties();

      IEnumerable<IGrouping<PropertyInfo, PropertyInfo>> propertyMappings = fromProperties.Select(fromProperty => GenerateFromPropertyRelatedToProperties(fromProperty, toProperties));

      var toPropertyMappings = propertyMappings;

      Config.MappingDictionary[(typeof(FromType), typeof(ToType))] = toPropertyMappings;
    }
    /// <summary>
    /// 生成一个属性的映射关系
    /// </summary>
    /// <param name="fromProperty"></param>
    /// <param name="toProperties"></param>
    /// <returns></returns>
    public virtual IGrouping<PropertyInfo, PropertyInfo> GenerateFromPropertyRelatedToProperties(PropertyInfo fromProperty, IEnumerable<PropertyInfo> toProperties) {

      IEnumerable<PropertyInfo> relatedProperties = null;

      var caseStyles = Config.ToTypePropertyNameCaseStyles;
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
      var propertyMappingGroup = relatedProperties.GroupBy(c => fromProperty).First();
      return propertyMappingGroup;
    }
    public ToType Convert(FromType fromObject, IServiceProvider serviceProvider) {
      var mappingInfo = GetMappingInfo(serviceProvider);
      return null;
    }

    public IEnumerable<ToType> Convert(IEnumerable<FromType> fromObjects, IServiceProvider serviceProvider) {
      throw new NotImplementedException();
    }
  }
}
