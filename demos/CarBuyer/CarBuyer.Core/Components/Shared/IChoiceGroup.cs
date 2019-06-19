using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBuyer.Core.Components.Shared
{
    public interface IChoiceGroup
    {
        object Value { get; }
        Task SetValueAsync(object value);
    }
}
