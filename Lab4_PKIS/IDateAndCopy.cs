using System;

namespace Lab4_PKIS
{
    public interface IDateAndCopy
    {
        DateTime Date { get; set; }
        object DeepCopy();
    }
}
