using Kirovpper.CaseConverter;
using Kirovpper.Enums;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Kirovpper {
  public static class Config {
    /// <summary>
    /// 是否自动根据Name转换 需要配置<see cref="ToNameCaseStyles"/>。
    /// </summary>
    public static bool AutoMappingWithName { get; set; }
    /// <summary>
    /// 目标编码风格。
    /// </summary>
    public static CaseStyle TargetPropertyNameCaseStyles { get; set; }
    /// <summary>
    /// ToType FromType ToPropertyInfo FromPropertyInfo之间的映射。
    /// </summary>
    public static IDictionary<(Type, Type), IEnumerable<(PropertyInfo, PropertyInfo)>> MappingDictionary = new ConcurrentDictionary<(Type, Type), IEnumerable<(PropertyInfo, PropertyInfo)>>();
    /// <summary>
    /// Converters
    /// </summary>
    public static IEnumerable<ICaseConverter> Converters { get; set; }
    /// <summary>
    /// Custom converters
    /// </summary>
    public static IEnumerable<ICaseConverter> CustomConverters { get; set; }
  }
}
