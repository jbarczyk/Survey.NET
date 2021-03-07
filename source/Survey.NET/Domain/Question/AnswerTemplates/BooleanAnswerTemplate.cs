using System;

namespace Survey.NET.Domain.Question.AnswerTemplates
{
    public class BooleanAnswerTemplate : IAnswerTemplate
    {
        public BooleanAnswerTemplate(string hint)
        {
            Hint = hint ?? throw new ArgumentNullException(nameof(hint));
        }

        public AnswerType Type => AnswerType.Boolean;
        public string Hint { get; }
    }
}