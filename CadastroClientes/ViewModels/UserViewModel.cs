using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroClientes.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Nome")]
        public string Name { get; set; }
        
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O Email é obrigatório.")]
        public string Mail { get; set; } //Poderia ser usado como login
        
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "A senha é obrigatório.")]
        public string Password { get; set; } 
        
        [Display(Name = "Endereço completo")]
        public string Address { get; set; }
        
        [Display(Name = "Ativo")]
        public bool Active { get; set; }
        
        [Display(Name = "Documento")]
        [Required(ErrorMessage = "O documento é obrigatório.")]
        public string Document { get; set; } //CPF
        
        [Display(Name = "Número de Telefone")]
        public string PhoneNumber { get; set; }
        
        [Display(Name = "Gênero")]
        public string Gender { get; set; } //M ou F
        
        [Display(Name = "Data de Nascimento")]
        public string BirthDate { get; set; }
    }
}
