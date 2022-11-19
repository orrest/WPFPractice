using Microsoft.Win32;
using SimpleMvvmDemo.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMvvmDemo.ViewModels
{
    /// <summary>
    /// [Save]
    /// [    ]
    /// [    ]
    /// [    ]
    /// [Add ]
    /// 两个命令属性, 三个数据属性.
    /// </summary>
    public class MainWindowViewModel : NotificationObject
    {
        private double _input1;
        public double Input1
        {
            get { return _input1; }
            set
            {
                _input1 = value;
                this.RaisePropertyChanged("Input1");
            }
        }

        private double _input2;
        public double Input2
        {
            get { return _input2; }
            set
            {
                _input2 = value;
                this.RaisePropertyChanged("Input2");
            }
        }

        private double _result;
        public double Result
        {
            get { return _result; }
            set
            {
                _result = value;
                this.RaisePropertyChanged("Result");
            }
        }

        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        private void Add(object parameter)
        {
            this.Result = this.Input1 + this.Input2;
        }
        private void Save(object parameter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.ShowDialog();
        }

        public MainWindowViewModel()
        {
            this.AddCommand = new DelegateCommand();
            this.AddCommand.ExecuteAction = new Action<object>(this.Add);

            this.SaveCommand = new DelegateCommand();
            this.SaveCommand.ExecuteAction = new Action<object>(this.Save);
        }
    }
}
