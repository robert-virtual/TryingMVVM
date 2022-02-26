using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace TryingMVVM
{
    public class MyViewModel : ObservableObject
    {
        private ApplicationDataStorageHelper helper;
        private UserSerializer mySerializer = new UserSerializer();
        public MyViewModel()
        {
            IncrementCounterCommand = new RelayCommand(IncrementCounter);
            ShowNombreCommand = new RelayCommand(ShowNombre);
            AddNombreCommand = new RelayCommand(AddNombre);
            RemoveNombreCommand = new RelayCommand<Guid>(RemoveNombre);
            helper = ApplicationDataStorageHelper.GetCurrent(mySerializer);
            if (helper.KeyExists("names"))
            {

                Names = helper.Read<ObservableCollection<Usuario>>("names");
                return;
            }
            Names = new ObservableCollection<Usuario>();
        }
       

       
        private int counter;

        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        
        private Usuario _usuario;
        public Usuario Usuario
        {
            get => _usuario;
            set => SetProperty(ref _usuario, value);
        }
        private ObservableCollection<Usuario> _names;

        public ObservableCollection<Usuario> Names
        {
            get => _names;
            private set => SetProperty(ref _names, value);
        }



        public int Counter
        {
            get => counter;
            private set => SetProperty(ref counter, value);
        }
        public ICommand IncrementCounterCommand { get; }
        private void IncrementCounter() => Counter++;

        public ICommand AddNombreCommand { get; }
        private void AddNombre() 
        {
            Names.Add(new Usuario() { Nombre = Name });
            helper.Save("names", Names);
            Name = "";
        }
        
        public ICommand RemoveNombreCommand { get; }
        private void RemoveNombre(Guid id) 
        {

            
            Names.Remove(Names.FirstOrDefault(item => item.Id == id));
            helper.Save("names", Names);
        }

        public ICommand ShowNombreCommand { get; }
        private void ShowNombre() 
        {
            

        }


    }
}
