using System;
using System.Collections.Generic;

namespace Survey.NET.Domain.Question.Descriptions
{
    public class TextQuestionDescription : QuestionDescription
    {
        private readonly string _description;

        public TextQuestionDescription(string description)
        {
            _description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public override string PlainText() => _description;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _description;
        }
    }
}