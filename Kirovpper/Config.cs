using Kirovpper.CaseConverters;
using Kirovpper.Enums;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Kirovpper {
  public static class Config {
    private static bool _initialed = false;
    private static object _lock;
    public static IServiceProvider ServiceProvider { get; private set; }

    public static void Initial(IServiceProvider serviceProvider) {
      lock (_lock) {
        if (_initialed == false) {
          var converters = new List<ICaseConverter>();
          if (ToTypePropertyNameCaseStyles.HasFlag(CaseStyle.PascalCase))
            converters.Add(new PascalCaseConverter());
          if (ToTypePropertyNameCaseStyles.HasFlag(CaseStyle.SnakeCase))
            converters.Add(new SnakeCaseConverter());
          if (ToTypePropertyNameCaseStyles.HasFlag(CaseStyle.CamelCase))
            converters.Add(new CamelCaseConverter());
          ServiceProvider = serviceProvider;
          _initialed = true;
          Converters = converters;
        }
      }
    }
    /// <summary>
    /// 是否自动根据Name转换 需要配置<see cref="ToNameCaseStyles"/>。
    /// </summary>
    public static bool AutoMappingWithName { get; set; }
    /// <summary>
    /// 目标编码风格。
    /// </summary>
    public static CaseStyle ToTypePropertyNameCaseStyles { get; set; }
    /// <summary>
    /// 类型转换映射表
    /// </summary>
    public static IDictionary<(Type, Type), IEnumerable<IGrouping<PropertyInfo, PropertyInfo>>> DefaultMapperMappingDictionary = new ConcurrentDictionary<(Type, Type), IEnumerable<IGrouping<PropertyInfo, PropertyInfo>>>();
    /// <summary>
    /// Case converters
    /// </summary>
    public static IEnumerable<ICaseConverter> Converters { get; set; }
    /// <summary>
    /// Custom case converters
    /// </summary>
    public static IEnumerable<ICaseConverter> CustomConverters { get; set; }
  }
}
