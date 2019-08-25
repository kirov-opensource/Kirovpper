using System;
using System.Collections.Generic;
using System.Text;

namespace Kirovpper.ColumnConverters {
  public interface IColumnConverter<FromType, ToType> {
    /// <summary>
    /// Custom convert
    /// </summary>
    /// <param name="fromValue"></param>
    /// <returns></returns>
    ToType Convert(FromType fromValue, IServiceProvider serviceProvider);
  }
}
