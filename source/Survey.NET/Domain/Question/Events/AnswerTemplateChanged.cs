using System;
using Survey.NET.Common;
using Survey.NET.Domain.Identifiers;

namespace Survey.NET.Domain.Question.Events
{
    public sealed class AnswerTemplateChanged : Event
    {
        public AnswerTemplateChanged(QuestionIdentifier id, AnswerTemplate template)
        {
            Template = template;
            Id = id.RawValue;
        }

        public Guid Id { get; }
        public AnswerTemplate Template { get; }
    }
}