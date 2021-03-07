using System;

namespace Survey.NET.Domain.Question.AnswerTemplates
{
    public class PlainTextAnswerTemplate : IAnswerTemplate
    {
        public PlainTextAnswerTemplate(string hint)
        {
            Hint = hint ?? throw new ArgumentNullException(nameof(hint));
        }

        public AnswerType Type => AnswerType.PlainText;
        public string Hint { get; }
    }
}