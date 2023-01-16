using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_2_依赖对象和依赖属性
{
    partial class MainWindowViewModel: ObservableObject
    {
        [ObservableProperty]
        private string fakeThing = "I am a fake text box!";
    }
}
