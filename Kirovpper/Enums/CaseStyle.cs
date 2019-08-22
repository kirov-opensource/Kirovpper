using System;
using System.Collections.Generic;
using System.Text;

namespace Kirovpper.Enums {
  [Flags]
  public enum CaseStyle {
    /// <summary>
    /// None.
    /// </summary>
    None = 0,
    /// <summary>
    /// Convert a string to camel case. Implement at <see cref="CaseConverter.CamelCaseConverter"/>.
    /// </summary>
    CamelCase = 1 << 0,
    /// <summary>
    /// Convert a string to pascal case. Implement at <see cref="CaseConverter.PascalCaseConverter"/>.
    /// </summary>
    PascalCase = 1 << 1,
    /// <summary>
    /// Convert a string to snake case. Implement at <see cref="CaseConverter.SnakeCaseConverter"/>.
    /// </summary>
    SnakeCase = 1 << 2,
    /// <summary>
    /// Raw.
    /// </summary>
    Raw = 1 << 3,
    /// <summary>
    /// Ignore case.
    /// </summary>
    IgnoreCase = 1 << 6
  }
}
