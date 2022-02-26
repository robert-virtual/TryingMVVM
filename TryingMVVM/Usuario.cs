using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TryingMVVM
{
    public class Usuario
    {

        public Usuario()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        
       

    }
}
