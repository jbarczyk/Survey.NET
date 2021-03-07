using System;
using System.Linq;
using Survey.NET.Domain.Question;
using Survey.NET.Domain.Question.AnswerTemplates;
using Survey.NET.Domain.Question.Descriptions;
using Survey.NET.Domain.Question.Events;
using Xunit;
using static Survey.NET.Tests.QuestionTests.QuestionBuilder;

namespace Survey.NET.Tests.QuestionTests
{
    public class QuestionTests
    {
        [Fact]
        public void NewQuestion_Produce_QuestionCreated()
        {
            var id = Guid.NewGuid();
            var question = GivenQuestion().WithId(id).Build();

            var events = question.GetUncommittedChanges().ToList();
            Assert.Single(events);
            Assert.Contains(events, x =>
                x is QuestionCreated @event &&
                @event.Id.Equals(id));
        }

        [Fact]
        public void ChangeDescription_Produce_ChangedDescription()
        {
            var id = Guid.NewGuid();
            var question = GivenQuestion().WithId(id).Build();

            question.ChangeDescription(new TextQuestionDescription("Test"));

            var events = question.GetUncommittedChanges().ToList();
            Assert.Equal(2, events.Count);
            Assert.Contains(events, x =>
                x is QuestionDescriptionChanged @event &&
                @event.Id.Equals(id));
        }

        [Fact]
        public void ChangeDescription_ResultsIn_ChangedPlainTextDescription()
        {
            var id = Guid.NewGuid();
            var question = GivenQuestion().WithId(id).Build();

            question.ChangeDescription(new TextQuestionDescription("Test"));

            var desc = question.PlainTextDescription();
            Assert.Equal("Test", desc);
        }

        [Fact]
        public void ChangeTemplate_Produce_ChangedTemplate()
        {
            var id = Guid.NewGuid();
            var question = GivenQuestion().WithId(id).Build();

            question.ChangeTemplate(new BooleanAnswerTemplate("Hint"));

            var events = question.GetUncommittedChanges().ToList();
            Assert.Equal(2, events.Count);
            Assert.Contains(events, x =>
                x is QuestionTemplateChanged @event &&
                @event.Id.Equals(id));
        }

        [Fact]
        public void ChangeTemplate_ResultsIn_ChangedTemplateType()
        {
            var id = Guid.NewGuid();
            var question = GivenQuestion().WithId(id).Build();

            question.ChangeTemplate(new BooleanAnswerTemplate("Hint"));

            var type = question.AnswerType();
            Assert.Equal(AnswerType.Boolean, type);
        }
    }
}