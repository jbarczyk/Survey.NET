using System;
using System.Collections.Generic;

namespace Survey.NET.Domain.Question.AnswerTemplates
{
    public class PlainTextAnswerTemplate : AnswerTemplate
    {
        public PlainTextAnswerTemplate(string hint)
        {
            Hint = hint ?? throw new ArgumentNullException(nameof(hint));
        }

        public override AnswerType Type => AnswerType.PlainText;
        public string Hint { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
            yield return Hint;
        }
    }
}