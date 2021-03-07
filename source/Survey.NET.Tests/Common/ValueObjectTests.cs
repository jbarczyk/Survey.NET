using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Survey.NET.Domain.Common;
using Xunit;

namespace Survey.NET.Tests.Common
{
    public class EmptyValueObject : ValueObject
    {
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield break;
        }
    }

    public class TestValueObject : ValueObject
    {
        public Guid DoesNotEventMatter { get; set; } = Guid.NewGuid();
        public int Number { get; set; } = 1;
        public string Text { get; set; } = "Sample";

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
            yield return Text;
        }
    }

    public class ValueObjectTests
    {
        [Theory]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public void Equals_Handles_Nulls(bool leftNull, bool rightNull)
        {
            var left = leftNull ? null : new TestValueObject();
            var right = rightNull ? null : new TestValueObject();

            Assert.NotEqual(left, right);
        }

        [Fact]
        public void Equals_Handles_OnlyEqualityComponents()
        {
            var left = new TestValueObject();
            var right = new TestValueObject();

            Assert.NotEqual(left.DoesNotEventMatter, right.DoesNotEventMatter);
            Assert.Equal(right, left);
            Assert.Equal(right.GetHashCode(), left.GetHashCode());
        }

        [Fact]
        public void Equals_Handles_SameObject()
        {
            var left = new TestValueObject();

            Assert.Equal(left, left);
        }

        [Fact]
        public void Equals_Handles_ObjectsWithSameValues()
        {
            var left = new TestValueObject
            {
                Number = 3,
                Text = "Test"
            };

            var right = new TestValueObject()
            {
                Number = 3,
                Text = "Test"
            };

            Assert.Equal(left, left);
        }

        [Fact]
        public void Equals_Handles_AnotherTypes()
        {
            var left = new TestValueObject();
            var right = new EmptyValueObject();

            Assert.NotEqual<ValueObject>(left, right);
        }
    }
}
