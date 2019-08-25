using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Kirovpper.Attributes {
  [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
  public class Mapper : Attribute {
    public Mapper(Type fromType, string fromPropertyName, [CallerMemberName] string memberName = null) {
      this.FromType = fromType;
      this.FromPropertyName = fromPropertyName;
      this.ToPropertyName = memberName;
    }
    public Mapper(Type fromType, string fromPropertyName, Type CustomConvert, [CallerMemberName] string memberName = null) {
      this.FromType = fromType;
      this.FromPropertyName = fromPropertyName;
      this.ToPropertyName = memberName;
      this.CustomConvert = CustomConvert;
    }

    /// <summary>
    /// 来源类型
    /// </summary>
    public Type FromType { get; set; }
    /// <summary>
    /// 来源列明
    /// </summary>
    public string FromPropertyName { get; set; }
    /// <summary>
    /// To列名
    /// </summary>
    public string ToPropertyName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Type CustomConvert { get; set; }
  }
}
