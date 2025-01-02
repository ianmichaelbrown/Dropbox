using Dropbox.Interfaces;
using System.Collections.Generic;

namespace Dropbox.Models
{
    class Model : IModel
    {
        public string InputFolderPath { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string TargetFolderPath { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool IsSyncing { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public Queue<string> FileCopyPathQueue { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public Queue<string> FileDeletePathQueue { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void AddToCopyQueue(string path)
        {
            throw new System.NotImplementedException();
        }

        public void AddToDeleteQueue(string path)
        {
            throw new System.NotImplementedException();
        }

        public void SetInputPath(string path)
        {
            throw new System.NotImplementedException();
        }

        public void SetSyncState(bool isSyncing)
        {
            throw new System.NotImplementedException();
        }

        public void SetTargetPath(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}
