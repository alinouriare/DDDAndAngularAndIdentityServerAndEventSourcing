using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructure.Networking
{
    public interface IFileDownloader
    {
        void DownloadFile(string url, string path);
    }
}
