using Kirovpper.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kirovpper.CaseConverter {
  public class SnakeCaseConverter : ICaseConverter {
    public string Convert(string rawString) {
      return rawString.ToSnakeCase();
    }
  }
}
