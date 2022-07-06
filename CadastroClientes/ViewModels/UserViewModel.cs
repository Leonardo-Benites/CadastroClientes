using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroClientes.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; } 
        public string Password { get; set; } 
        public string Address { get; set; }
        public bool Active { get; set; }
        public string Document { get; set; } //CPF
        public string PhoneNumber { get; set; }
        public string Gender { get; set; } //M ou F
        public DateTime BirthDate { get; set; }
    }
}
