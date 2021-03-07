using Survey.NET.Domain.Common;

namespace Survey.NET.Domain.Question
{
    public abstract class AnswerTemplate : ValueObject
    {
        public abstract AnswerType Type { get; }
    }
}