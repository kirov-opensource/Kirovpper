using Kirovpper.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kirovpper.Extensions {
  public static class KirovpperExtension {

    public static ToType ToModel<FromType, ToType>(this FromType fromObject) where FromType : class, new() where ToType : class, new() {
      ToType toObject = new ToType();
      if (toObject is IMapper<FromType, ToType> customMapper) {
        toObject = customMapper.Convert(fromObject, Config.ServiceProvider);
      }
      else {
        toObject = new DefaultMapper<FromType, ToType>().Convert(fromObject, Config.ServiceProvider);
      }
      return toObject;
    }

    public static ToType ToModel<FromType, ToType>(this FromType fromObject, out ToType toObject) where FromType : class, new() where ToType : class, new() {
      if (typeof(ToType) is IMapper<FromType, ToType> customMapper) {
        toObject = customMapper.Convert(fromObject, Config.ServiceProvider);
      }
      else {
        toObject = new DefaultMapper<FromType, ToType>().Convert(fromObject, Config.ServiceProvider);
      }
      return toObject;
    }

  }
}
