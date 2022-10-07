using System;
using System.ComponentModel.DataAnnotations;
using API_Folhas.Validations;

namespace API_Folhas.Models
{
    public class Funcionario
    {
        //Data Annotations
        public Funcionario() => CriadoEm = DateTime.Now;
        public int funcionarioId { get; set; }

        public string Nome { get; set; }
       
        public string Cpf { get; set; }

        public DateTime Nascimento { get; set; }

        public DateTime CriadoEm { get; set; }

        // public override string ToString()
        // {
        //     return base.ToString();
        // }
    }
}