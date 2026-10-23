using Ast.Common.Mvvm.Commands;
using Ast.Common.Mvvm.ViewModels;
using DocumentNumber.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Media.Media3D;

namespace DocumentNumber.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        ObservableCollection<string> _documentNumbers;
        public ObservableCollection<string> DocumentNumbers
        {
            get { return _documentNumbers; }
            set { _documentNumbers = value; }
        }

        ObservableCollection<string> _documents;
        public ObservableCollection<string> Documents
        {
            get { return _documents; }
            set { SetProperty(ref _documents, value); }
        }

        string title_;
        public string Title
        {
            get { return title_; }
            set { SetProperty(ref title_, value); }
        }

        string subject;
        public string Subject
        {
            get => subject;
            set => SetProperty(ref subject, value);
        }

        string author;
        public string Author
        {
            get => author;
            set => SetProperty(ref author, value);
        }

        string keywords;
        public string Keywords
        {
            get => keywords;
            set => SetProperty(ref keywords, value);
        }

        string comments;
        public string Comments
        {
            get => comments;
            set => SetProperty(ref comments, value);
        }

        string company;
        public string Company
        {
            get => company;
            set => SetProperty(ref company, value);
        }

        string documentNumber;
        public string DocumentNumber
        {
            get => documentNumber;
            set => SetProperty(ref documentNumber, value);
        }

        string revision;
        public string Revision
        {
            get => revision;
            set => SetProperty(ref revision, value);
        }

        string projectName;
        public string ProjectName
        {
            get => projectName;
            set => SetProperty(ref projectName, value);
        }

        public DelegateCommand OpenFolderCommand { get; }

        private FolderOpenerService _folderOpener;
        private string _selectedFolder;

        public MainWindowViewModel(FolderOpenerService folderOpener)
        {
            OpenFolderCommand = new DelegateCommand(OpenFolder);
            _folderOpener = folderOpener;
        }

        private void OpenFolder()
        {
            _selectedFolder = _folderOpener.OpenFolder();

            if(string.IsNullOrEmpty(_selectedFolder))
                return;

            DirectoryInfo files = new DirectoryInfo(_selectedFolder);

            Documents = new ObservableCollection<string>(files.GetFiles("*.par").ToList().Select(f => f.Name));
        }
    }
}
