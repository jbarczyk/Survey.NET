using System;
using Survey.NET.Domain.Identifiers;
using Survey.NET.Domain.Question;
using Survey.NET.Domain.Question.AnswerTemplates;
using Survey.NET.Domain.Question.Descriptions;

namespace Survey.NET.Tests.QuestionTests
{
    internal class QuestionBuilder
    {
        private AnswerTemplate _template = new PlainTextAnswerTemplate("Hint");
        private QuestionDescription _description = new TextQuestionDescription("Description");
        private Guid _id = Guid.NewGuid();

        private QuestionBuilder() { }

        public static QuestionBuilder GivenQuestion() => new QuestionBuilder();

        public QuestionBuilder WithTemplate(AnswerTemplate template)
        {
            _template = template;
            return this;
        }

        public QuestionBuilder WithDescription(QuestionDescription description)
        {
            _description = description;
            return this;
        }

        public QuestionBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public Question Build() => Question.Create(new QuestionIdentifier(_id), _description, _template);
    }
}
