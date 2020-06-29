using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PxWebComparer.Business
{
    public interface IExcelComparer
    {
        ArrayList ReadExcelFile(string fileName);
    }
}
