using System.ComponentModel.DataAnnotations;

namespace API_FOlhas.Models
{
    public class Folha
    {
        
        public int mes { get; set; }

        public int ano { get; set; }

        public double valorhora { get; set; }

         public int quantidadehoras { get; set; }

        public string cpf { get; set; } 

    }
}