using System;
using System.Collections.Generic;
using System.Text;

namespace Kirovpper.Tests.Enums {
  [Flags]
  public enum Status {
    None = 1 << 0,
    Avaliable = 1 << 1,
    Disabled = 1 << 2,
    AlreadyBanned = 1 << 4
  }
}
