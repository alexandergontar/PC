using WMI.Services;

namespace WMI
{
    class Program
    {      
        static void Main(string[] args)
        {            
            new BL(new WebAPIClient(),
                     new CompInfo())
                      .Run();
        }
    }
}
