using System;
using System.Collections.Generic;

namespace Survey.NET.Domain.Question.AnswerTemplates
{
    public class BooleanAnswerTemplate : AnswerTemplate
    {
        public BooleanAnswerTemplate(string hint)
        {
            Hint = hint ?? throw new ArgumentNullException(nameof(hint));
        }

        public override AnswerType Type => AnswerType.Boolean;
        public string Hint { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
            yield return Hint;
        }
    }
}