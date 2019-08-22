using Kirovpper.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kirovpper.CaseConverter {
  /// <summary>
  /// CaseStyleConverter
  /// </summary>
  public interface ICaseConverter {
    /// <summary>
    /// 转换
    /// </summary>
    /// <param name="rawString">原始字符串</param>
    /// <returns></returns>
    string Convert(string rawString);
  }
}
