using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentNumberCalculator.Serivce
{
    public interface IComputerDocumentNumbers
    {
        string ComputeDocumentNumber(DocumentNumberOptions options);
    }
}
