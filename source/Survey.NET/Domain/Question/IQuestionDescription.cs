using Survey.NET.Domain.Common;

namespace Survey.NET.Domain.Question
{
    public abstract class QuestionDescription : ValueObject
    {
        public abstract string PlainText();
    }
}