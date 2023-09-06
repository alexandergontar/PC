using WMI.Services;
using WMI.Model;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;

namespace WMI
{

    public class BL
    {
        private IClient client;
        private IPcmanager manager;

        public BL(IClient client, IPcmanager manager) 
        {
            this.client = client;
            this.manager = manager;
        }

        public void Run() 
        {
            PC pc = manager.GetInfo("localhost");
            string jsonData = JsonConvert.SerializeObject(pc);
            // Test Deserialization
            /*PC pc1 = JsonConvert.DeserializeObject<PC>(jsonData);
            foreach (Disk disk in pc1.Disks)
            {
                Console.WriteLine("{0}   {1}   {2}",
                    disk.DiskName, disk.VolumeSize, disk.FreeSpace);
            }
            foreach (string item in pc1.PcItems)
            {
                Console.WriteLine(item);
            }*/
            Console.WriteLine("\n ===== JSON data ===== :");
            Console.WriteLine(jsonData);

            Console.WriteLine("\n ===== Post JSON data, waiting for response .... \n");
           // Task<string> result = client.sendPost(jsonData, "https://httpbin.org/post");
            Task<string> result = client.sendPost(jsonData, "https://localhost:44370/api/PCs");
            result.Wait();
            Console.WriteLine(result.Result.ToString());
            Console.ReadKey();
        }

    }
}
