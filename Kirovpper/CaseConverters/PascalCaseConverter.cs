using Kirovpper.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kirovpper.CaseConverters {
  class PascalCaseConverter : ICaseConverter {
    public string Convert(string rawString) {
      return rawString.ToPascalCase();
    }
  }
}
