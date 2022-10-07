using System;
using System.ComponentModel.DataAnnotations;
using API_Folhas.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class FolhaPagamento
    {
        public FolhaPagamento() => CriadoEm = DateTime.Now;

        [ForeignKey("funcionario")]
        public int funcionarioId { get; set; }
        public Funcionario funcionario { get; set; }

        [Key]
        public int Id { get; set; }

        public int mes { get; set; }
        
        public int ano { get; set; }

        public double valorHora { get; set; }

        public int quantidadeHoras { get; set; }

        public DateTime CriadoEm { get; set; }

        public double salarioBruto => SalarioBruto();

        public double impostoFGTS => impostoFgts();

        public double impostoINSS => impostoInss();

        public double impostoRenda => ImpostoRenda();

        public double salarioLiquido => SalarioLiquido();

        private double SalarioBruto()
        {
            return valorHora * quantidadeHoras;
        }

        private double SalarioLiquido(){
            return salarioBruto - impostoRenda - impostoINSS;
        }

        
        private double impostoFgts(){
            return salarioBruto * 0.08;
        }

        private double impostoInss(){
            if (salarioBruto <= 1693.72) {
                return salarioBruto * 0.08;
            }
            else if (salarioBruto <= 2882.90){
                return salarioBruto * 0.09;
            }
            else if (salarioBruto <= 5645.80){
                return salarioBruto * 0.11;
            }
            else{
                return 621.03;
            }
        }

        private double ImpostoRenda()
        {

            if (salarioBruto <= 1903.98){
                return salarioBruto * 0;
            }
            else if (salarioBruto <= 2826.65){
                return salarioBruto * 0.075;
            }
            else if (salarioBruto <= 3751.05){
                return salarioBruto * 0.15;
            }
            else if (salarioBruto <= 4664.68){
                return salarioBruto * 0.225;
            }
            else {
                return salarioBruto * 0.275;
            }
        }

        
    }
}