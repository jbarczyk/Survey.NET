using System;
using Survey.NET.Common;
using Survey.NET.Domain.Identifiers;
using Survey.NET.Domain.Question;
using Survey.NET.Domain.Question.AnswerTemplates;
using Survey.NET.Domain.Question.Descriptions;
using Survey.NET.Domain.Question.Events;
using Survey.NET.ReadModels.Questions;
using Xunit;

namespace Survey.NET.Tests.QuestionTests
{
    public class QuestionDtoTests
    {
        [Fact]
        public void Should_Compose_CorrectReadModel()
        {
            var id = new QuestionIdentifier(Guid.NewGuid());
            var dto = new QuestionDto();
            dto.Apply(
                new Event[]
                {
                    new QuestionCreated(id, new TextQuestionDescription("Desc"), new PlainTextAnswerTemplate("Hint")),
                    new AnswerTemplateChanged(id, new BooleanAnswerTemplate("Hint")),
                    new QuestionDescriptionChanged(id, new TextQuestionDescription("Test"))
                });

            Assert.Equal(id.RawValue, dto.Id);
            Assert.Equal(AnswerType.Boolean, dto.AnswerType);
            Assert.Equal("Test", dto.PlainTextDescription);
        }
    }
}
