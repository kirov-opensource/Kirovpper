using System;
using System.Collections.Generic;
using System.Text;

namespace Kirovpper.Extensions {
  public static class StringCaseExtension {
    /// <summary>
    /// Convert to PascalCase
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string ToPascalCase(this string s) {
      if (string.IsNullOrWhiteSpace(s)) {
        return s;
      }

      var builder = new StringBuilder();
      bool wordBreaked = true;
      foreach (char c in s) {
        if (char.IsWhiteSpace(c) || c == '.' || c == '-' || c == '_') {
          wordBreaked = true;
          continue;
        }
        if (wordBreaked) {
          builder.Append(char.ToUpper(c));
          wordBreaked = false;
        }
        else if (char.IsUpper(c)) {
          builder.Append(c);
        }
        else {
          builder.Append(char.ToLower(c));
        }
      }
      return builder.ToString();
    }

    /// <summary>
    /// Convert to camelCase
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string ToCamelCase(this string s) {
      if (string.IsNullOrEmpty(s) || !char.IsUpper(s[0])) {
        return s;
      }
      char[] chars = s.ToCharArray();
      for (int i = 0; i < chars.Length; i++) {
        if (i == 1 && !char.IsUpper(chars[i])) {
          break;
        }
        bool hasNext = (i + 1 < chars.Length);
        if (i > 0 && hasNext && !char.IsUpper(chars[i + 1])) {
          if (char.IsSeparator(chars[i + 1])) {
            chars[i] = ToLower(chars[i]);
          }
          break;
        }
        chars[i] = ToLower(chars[i]);
      }
      return new string(chars);
    }

    /// <summary>
    /// Convert to snake_case
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string ToSnakeCase(this string s) {
      if (string.IsNullOrEmpty(s)) {
        return s;
      }
      var sb = new StringBuilder();
      var state = SnakeCaseState.Start;
      for (int i = 0; i < s.Length; i++) {
        if (s[i] == ' ') {
          if (state != SnakeCaseState.Start) {
            state = SnakeCaseState.NewWord;
          }
        }
        else if (char.IsUpper(s[i])) {
          switch (state) {
            case SnakeCaseState.Upper:
              bool hasNext = (i + 1 < s.Length);
              if (i > 0 && hasNext) {
                char nextChar = s[i + 1];
                if (!char.IsUpper(nextChar) && nextChar != '_') {
                  sb.Append('_');
                }
              }
              break;
            case SnakeCaseState.Lower:
            case SnakeCaseState.NewWord:
              sb.Append('_');
              break;
          }
          char c;
          c = char.ToLowerInvariant(s[i]);
          sb.Append(c);
          state = SnakeCaseState.Upper;
        }
        else if (s[i] == '_') {
          sb.Append('_');
          state = SnakeCaseState.Start;
        }
        else {
          if (state == SnakeCaseState.NewWord) {
            sb.Append('_');
          }
          sb.Append(s[i]);
          state = SnakeCaseState.Lower;
        }
      }
      return sb.ToString();
    }
    private static char ToLower(char c) {
      c = char.ToLowerInvariant(c);
      return c;
    }

    internal enum SnakeCaseState {
      Start,
      Lower,
      Upper,
      NewWord
    }
  }
}
