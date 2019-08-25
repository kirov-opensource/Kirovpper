using Kirovpper.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kirovpper.ColumnConverters {
  public class StringToEnumConverter<ToEnum> : IColumnConverter<string, ToEnum> where ToEnum : Enum {
    public ToEnum Convert(string fromObject, IServiceProvider serviceProvider) {
      try {
        var result = Enum.Parse(typeof(ToEnum), fromObject.ToPascalCase());
        return (ToEnum)result;
      }
      catch {
        return default;
      }
    }
  }
}
