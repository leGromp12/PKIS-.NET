using System;

namespace Lab1_PKIS
{
    public interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; init; }
    }
}