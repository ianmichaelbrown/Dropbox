﻿using Dropbox.Interfaces;
using System;

namespace Dropbox.Commands
{
    partial class SelectFolderCommand : ISelectFolderCommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
