using System;

namespace Lab5_PKIS
{
    public interface IDateAndCopy
    {
        DateTime Date { get; set; }
        object DeepCopy();
    }
}
