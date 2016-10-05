using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sis.Interview.Api.Framework
{ 
    public class FilledCollectionAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (!(value is IEnumerable<object>)) return false;
            return base.IsValid(value) && ((IEnumerable<object>) value).Any();
        }
    }
}