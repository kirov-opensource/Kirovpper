using Kirovpper.Mapper;
using Kirovpper.Tests.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kirovpper.Tests.ViewModels {
  public class FooViewModel : IMapper<Foo, FooViewModel>, IMapper<Foo1, FooViewModel> {
    public string Foo { get; set; }
    public string Bar { get; set; }

    FooViewModel IMapper<Foo, FooViewModel>.Convert(Foo fromObject, IServiceProvider serviceProvider) {
      this.Foo = fromObject.foo;
      this.Bar = fromObject.create_at.ToString("yyyy-MM-dd");
      return this;
    }

    IEnumerable<FooViewModel> IMapper<Foo, FooViewModel>.Convert(IEnumerable<Foo> fromObjects, IServiceProvider serviceProvider) {
      throw new NotImplementedException();
    }

    FooViewModel IMapper<Foo1, FooViewModel>.Convert(Foo1 fromObject, IServiceProvider serviceProvider) {
      throw new NotImplementedException();
    }

    IEnumerable<FooViewModel> IMapper<Foo1, FooViewModel>.Convert(IEnumerable<Foo1> fromObjects, IServiceProvider serviceProvider) {
      throw new NotImplementedException();
    }
  }
}
