using System;
using System.Collections.Generic;
using System.Text;

namespace Kirovpper.Mapper {
  public interface IMapper<FromType, ToType>
    where FromType : class, new() where ToType : class, new() {
    /// <summary>
    /// Custom convert
    /// </summary>
    /// <param name="fromObject"></param>
    /// <returns></returns>
    ToType Convert(FromType fromObject, IServiceProvider serviceProvider);
    /// <summary>
    /// Custom converts
    /// </summary>
    /// <param name="fromObjects"></param>
    /// <returns></returns>
    IEnumerable<ToType> Convert(IEnumerable<FromType> fromObjects, IServiceProvider serviceProvider);
  }
}
