using WMI.Model;

namespace WMI.Services
{
    public interface IPcmanager
    {
        public PC GetInfo(string host);
    }
}
