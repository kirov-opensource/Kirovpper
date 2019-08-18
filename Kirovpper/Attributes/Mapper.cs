using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Kirovpper.Attributes {
  [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
  public class Mapper : Attribute {
    //public Mapper([CallerMemberName] string memberName) {
    //}

    /// <summary>
    /// 来源类型
    /// </summary>
    private Type SourceType { get; set; }
    /// <summary>
    /// 来源列
    /// </summary>
    private string SourceColumn { get; set; }
  }
}
