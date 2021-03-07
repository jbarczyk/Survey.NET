using System;
using Survey.NET.Domain.Common;
using Survey.NET.Domain.Identifiers;
using Survey.NET.Domain.Question.Events;

namespace Survey.NET.Domain.Question
{
    public class Question : AggregateRoot
    {
        private IQuestionDescription _description;
        private IAnswerTemplate _template;

        private Question(QuestionIdentifier id, IQuestionDescription description, IAnswerTemplate template)
        {
            Id = id;
            _description = description ?? throw new ArgumentNullException(nameof(description));
            _template = template ?? throw new ArgumentNullException(nameof(template));
        }

        public QuestionIdentifier Id { get; }

        public void ChangeDescription(IQuestionDescription description)
        {
            _ = description ?? throw new ArgumentNullException(nameof(description));
            _description = description;

            ApplyChange(new QuestionDescriptionChanged(Id));
        }

        public void ChangeTemplate(IAnswerTemplate template)
        {
            _ = template ?? throw new ArgumentNullException(nameof(template));
            _template = template;

            ApplyChange(new QuestionTemplateChanged(Id));
        }

        public string PlainTextDescription() => _description.PlainText();

        public AnswerType AnswerType() => _template.Type;

        public static Question Create(QuestionIdentifier id, IQuestionDescription description, IAnswerTemplate template)
        {
            var newQuestion = new Question(id, description, template);
            newQuestion.ApplyChange(new QuestionCreated(id));
            return newQuestion;
        }
    }
}
