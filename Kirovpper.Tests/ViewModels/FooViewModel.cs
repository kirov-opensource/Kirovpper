using Kirovpper.Mapper;
using Kirovpper.Tests.Entities;
using Kirovpper.Tests.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kirovpper.Tests.ViewModels {
  public class FooViewModel : IMapper<Foo, FooViewModel> {
    public string Foo { get; set; }
    public Status Status { get; set; }
    public string Bar { get; set; }

    FooViewModel IMapper<Foo, FooViewModel>.Convert(Foo fromObject, IServiceProvider serviceProvider) {
      this.Foo = fromObject.foo;
      this.Bar = fromObject.create_at.ToString("yyyy-MM-dd");
      return this;
    }

    IEnumerable<FooViewModel> IMapper<Foo, FooViewModel>.Convert(IEnumerable<Foo> fromObjects, IServiceProvider serviceProvider) {
      throw new NotImplementedException();
    }

  }
}
