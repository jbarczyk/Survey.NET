using System;
using Survey.NET.Common;
using Survey.NET.Domain.Identifiers;

namespace Survey.NET.Domain.Question.Events
{
    public sealed class QuestionCreated : Event
    {
        public QuestionCreated(QuestionIdentifier id, QuestionDescription description, AnswerTemplate template)
        {
            Template = template;
            Description = description;
            Id = id.RawValue;
        }

        public Guid Id { get; }
        public AnswerTemplate Template { get; }
        public QuestionDescription Description { get; }
    }
}