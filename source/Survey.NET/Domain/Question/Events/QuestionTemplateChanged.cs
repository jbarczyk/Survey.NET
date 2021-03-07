using System;
using Survey.NET.Domain.Common;
using Survey.NET.Domain.Identifiers;

namespace Survey.NET.Domain.Question.Events
{
    public sealed class QuestionTemplateChanged : Event
    {
        public QuestionTemplateChanged(QuestionIdentifier id)
        {
            Id = id.RawValue;
        }

        public Guid Id { get; }
    }
}