using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentNumber.Services
{
    public class FolderOpenerService
    {

        public string OpenFolder(string folderPath = "")
        {
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();
            openFolderDialog.Title = "Select a folder";
            openFolderDialog.InitialDirectory = string.IsNullOrEmpty(folderPath) 
                ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) 
                : folderPath;
            openFolderDialog.Multiselect = false;
            if (true == openFolderDialog.ShowDialog())
            {
                return openFolderDialog.FolderName;

            }



            return folderPath;
        }
    }
}
