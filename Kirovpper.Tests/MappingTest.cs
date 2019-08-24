using Kirovpper.Extensions;
using Kirovpper.Tests.Entities;
using Kirovpper.Tests.ViewModels;
using System;
using Xunit;

namespace Kirovpper.Tests {
  public class MappingTest {

    [Fact]
    public void MappingTest1() {
      var foo = new Foo {
        create_at = DateTime.Now,
        foo = "bar"
      };
      var b = foo.ToModel<Foo, FooViewModel>();
    }
  }
}
