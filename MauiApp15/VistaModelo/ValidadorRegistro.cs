using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp15.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp15.VistaModelo
{
    public partial class ValidadorRegistro : ObservableValidator
    {
        public ObservableCollection<string> Errores { get; set; } = new ObservableCollection<string>();
        private String string1;
        [Required(ErrorMessage = "Debe de estar completo")]
        public String String1
        {
            get => string1;
            set => SetProperty(ref string1, value);
        }

        private String dni;
        [RegularExpression(@"^\d{9}[A-Z]$",ErrorMessage = "El dni tiene que ser válido")]
        public String Dni
        {
            get => dni;
            set => SetProperty(ref (dni), value);
        }

        private string edad;
        public String ? Edad
        {
            get => edad;
            set => SetProperty(ref edad, value);
        }

        [RelayCommand]
        public void validar()
        {
            ValidateAllProperties();
            Errores.Clear();
            GetErrors(nameof(String1)).ToList().ForEach(f => Errores.Add(f.ErrorMessage));
            GetErrors(nameof(Dni)).ToList().ForEach(f => Errores.Add(f.ErrorMessage));
            GetErrors(nameof(Edad)).ToList().ForEach(f => Errores.Add(f.ErrorMessage));

            if (Errores.Count == 0) 
            {

            }
        }
    }
}
