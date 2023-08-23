using System;
using System.Management;
using System.Collections.Generic;
using WMI.Model;

namespace WMI.Services
{
    public class CompInfo : IPcmanager
    {

        public PC GetInfo(string host)
        {
            List<Disk> disks = new List<Disk>();
            List<string> commonInfo = new List<string>();
            string compInfo = String.Empty;
            ManagementObjectSearcher searcher = null;
            ManagementObjectCollection queryCollection = null;
            PC pc = new PC();
            try
            {
                ConnectionOptions options = new ConnectionOptions();
                /* options.EnablePrivileges = true;
                 options.Impersonation = ImpersonationLevel.Impersonate;
                 options.Authentication = AuthenticationLevel.Default;
                 options.Authority = "ntlmdomain:pet.corp.jti.com";
                 options.Username = "cstgontaa";
                 options.Password = "N@talie-1917";*/

                ManagementScope scope = new ManagementScope(
                    "\\\\" + host + "\\root\\cimv2", options);
                scope.Connect();

                //Query system for Operating System information
                ObjectQuery query = new ObjectQuery(
                    "SELECT * FROM Win32_OperatingSystem");
                searcher =
                    new ManagementObjectSearcher(scope, query);

                queryCollection = searcher.Get();
                foreach (ManagementObject m in queryCollection)
                {
                    commonInfo.Add(String.Format("Computer Name : {0}\n", m["csname"]));
                    commonInfo.Add(String.Format("Windows Directory : {0}\n", m["WindowsDirectory"]));
                    commonInfo.Add(String.Format("Operating System: {0}\n", m["Caption"]));
                    commonInfo.Add(String.Format("Version: {0}\n", m["Version"]));
                    commonInfo.Add(String.Format("Manufacturer : {0}\n", m["Manufacturer"]));
                }
                query = new ObjectQuery("SELECT * FROM Win32_LogicalDisk");
                searcher = new ManagementObjectSearcher(scope, query);
                foreach (ManagementObject managementObject in searcher.Get())
                {
                    Disk disk = new Disk();
                    disk.DiskName = managementObject["Name"].ToString();
                    disk.VolumeSize = (UInt64)managementObject["Size"];
                    disk.FreeSpace = (UInt64)managementObject["FreeSpace"];
                    disks.Add(disk);
                }
                foreach (Disk d in disks)
                {
                    Console.WriteLine($"{d.DiskName}  {d.VolumeSize}  {d.FreeSpace}");
                }
                foreach (string item in commonInfo)
                {
                    compInfo += item;
                }
                Console.Write(compInfo);
                pc.Disks = disks;                
                pc.PcItems = commonInfo;
                return pc;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                foreach (Disk d in disks)
                {
                    Console.WriteLine($"{d.DiskName}  {d.VolumeSize}  {d.FreeSpace}");
                }
                foreach (string item in commonInfo)
                {
                    compInfo += item;
                }
                Console.Write(compInfo);
                pc.Disks = disks;                
                pc.PcItems = commonInfo;
                return pc;
            }
            finally
            {
                if (searcher != null)
                {
                    searcher.Dispose();
                }
                if (queryCollection != null)
                {
                    queryCollection.Dispose();
                }                
            }
        }

    }
}
