using System;
using Survey.NET.Common;
using Survey.NET.Domain.Identifiers;

namespace Survey.NET.Domain.Question.Events
{
    public sealed class QuestionDescriptionChanged : Event
    {
        public QuestionDescriptionChanged(QuestionIdentifier id, QuestionDescription description)
        {
            Description = description;
            Id = id.RawValue;
        }

        public Guid Id { get; }
        public QuestionDescription Description { get; }
    }
}