using System;
using Survey.NET.Domain.Common;
using Survey.NET.Domain.Identifiers;

namespace Survey.NET.Domain.Question.Events
{
    public sealed class QuestionDescriptionChanged : Event
    {
        public QuestionDescriptionChanged(QuestionIdentifier id)
        {
            Id = id.RawValue;
        }

        public Guid Id { get; }
    }
}