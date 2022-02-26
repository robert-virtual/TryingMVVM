using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryingMVVM
{
    public class User:ObservableObject
    {
        private int name;

        public int Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

    }
}
