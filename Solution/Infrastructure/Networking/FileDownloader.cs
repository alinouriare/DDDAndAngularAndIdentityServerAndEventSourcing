using Domain.Infrastructure.Networking;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Infrastructure.Networking
{
    public class FileDownloader : IFileDownloader
    {
        public void DownloadFile(string url, string path)
        {
            var client = new WebClient();
            client.DownloadFile(url, path);
        }
    }
}
