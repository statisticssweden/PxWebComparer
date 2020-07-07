using System.Collections;

namespace PxWebComparer.Business
{
    public interface IExcelComparer
    {
        ArrayList ReadExcelFile(string fileName);
    }
}
