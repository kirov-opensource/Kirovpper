using Kirovpper.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kirovpper.CaseConverter {
  public class CamelCaseConverter : ICaseConverter {
    public string Convert(string rawString) {
      return rawString.ToCamelCase();
    }
  }
}
