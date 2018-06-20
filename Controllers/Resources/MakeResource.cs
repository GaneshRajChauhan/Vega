using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega.Controllers.Resources
{
    public class MakeResource:KeyValuePairResource
    {
      public ICollection<KeyValuePairResource> models {get;set;}

      public MakeResource()
      {
          models=new   Collection<KeyValuePairResource>();
      }
    }
}