using System;
using System.Collections.Generic;
using Survey.NET.Domain.Common;

namespace Survey.NET.Domain.Identifiers
{
    public abstract class Identifier : ValueObject
    {
        protected Identifier(Guid id)
        {
            RawValue = id;
        }

        public Guid RawValue { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return RawValue;
        }
    }
}