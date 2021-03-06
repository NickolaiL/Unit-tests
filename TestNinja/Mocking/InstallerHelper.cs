﻿using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private IFileDownloader _fileDownloader;

        public InstallerHelper (IFileDownloader fileDownloader = null )
        {
            _fileDownloader = fileDownloader ?? new FileDownloader();
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            var client = new WebClient();
            try
            {
                string url = string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName);
                _fileDownloader.DownloadFile(url ,_setupDestinationFile);
                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }
}