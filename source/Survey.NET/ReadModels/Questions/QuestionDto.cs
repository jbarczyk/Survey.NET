using System;
using Survey.NET.Domain.Question;
using Survey.NET.Domain.Question.Events;
using Survey.NET.ReadModels.Common;

namespace Survey.NET.ReadModels.Questions
{
    public class QuestionDto : ReadModel
    {
        public QuestionDto()
        { }

        public Guid Id { get; private set; }
        public string PlainTextDescription { get; private set; }
        public AnswerType AnswerType { get; private set; }

        private void Apply(QuestionCreated @event)
        {
            Id = @event.Id;
            PlainTextDescription = @event.Description.PlainText();
            AnswerType = @event.Template.Type;
        }

        private void Apply(QuestionDescriptionChanged @event)
        {
            PlainTextDescription = @event.Description.PlainText();
        }

        private void Apply(AnswerTemplateChanged @event)
        {
            AnswerType = @event.Template.Type;
        }
    }
}
