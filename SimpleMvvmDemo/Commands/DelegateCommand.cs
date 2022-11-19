﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleMvvmDemo.Commands
{
    /// <summary>
    /// 一个很简陋的DelegateCommand, 不建议在生产环境中使用.
    /// (简陋在哪?)
    /// </summary>
    public class DelegateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (this.CanExecuteFunc == null)
            {
                return true;
            }
            return this.CanExecuteFunc(parameter);
        }

        public void Execute(object? parameter)
        {
            if (this.ExecuteAction == null)
            {
                return;
            }
            this.ExecuteAction(parameter);
        }

        public Action<object> ExecuteAction { get; set; }
        public Func<object, bool> CanExecuteFunc { get; set; }
    }
}
