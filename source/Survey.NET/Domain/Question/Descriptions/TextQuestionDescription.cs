using System;

namespace Survey.NET.Domain.Question.Descriptions
{
    public class TextQuestionDescription : IQuestionDescription
    {
        private readonly string _description;

        public TextQuestionDescription(string description)
        {
            _description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public string PlainText() => _description;
    }
}