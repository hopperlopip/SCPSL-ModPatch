using SCPSL_ModPatch.PatchUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Handlers;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SCPSL_ModPatch
{
    internal class Updater
    {
        const string PATCHINFO_LINK = "";

        public static void UpdatePatchInfo(string patchInfoPath)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(10);

            byte[] patchInfoFromNet;
            try
            {
                patchInfoFromNet = httpClient.GetByteArrayAsync(PATCHINFO_LINK).Result;
                File.WriteAllBytes(patchInfoPath, patchInfoFromNet);
            }
            catch { return; }
        }

        public static async void UpdatePatchInfoAsync(string patchInfoPath, CancellationToken cancellationToken = default)
        {
            HttpClient httpClient = new HttpClient();
            byte[] patchInfoFromNet;
            try
            {
                patchInfoFromNet = await httpClient.GetByteArrayAsync(PATCHINFO_LINK, cancellationToken);
                File.WriteAllBytes(patchInfoPath, patchInfoFromNet);
            }
            catch { return; }
        }
    }
}
