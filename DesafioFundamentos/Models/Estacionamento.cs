using System;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        private decimal precoInicial = precoInicial;
        private decimal precoPorHora = precoPorHora;
        private List<string> veiculos = [];

        private bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa)) return false; 
            
            if (placa.Length != 7) return false;

            if (char.IsLetter(placa, 4))
            {
                var padraoMercosul = new Regex(@"[a-zA-Z]{3}\d[a-zA-Z]\d{2}");
                return padraoMercosul.IsMatch(placa);
            }
            else if(char.IsDigit(placa, 4))
            {
                var padraoBrasil = new Regex(@"[a-zA-Z]{3}\d{4}");
                return padraoBrasil.IsMatch(placa);
            }
            else return false;
        }

        // Método para validar quantidade de horas estacionadas e retornar o valor total
        private decimal QuantidadeDeHoras(string horasString)
        {            
            int horas = 0;
            int tentativas = 0;
            decimal valorTotal = 0;

            // conversão e validação da quantidade de horas
            while (true)
            {
                if(!int.TryParse(horasString, out horas) || horas <= 0)
                {
                    Console.WriteLine("Valor inválido. Tente novamente."); 
                    horasString = Console.ReadLine(); 
                    tentativas ++;                  
                }
                else
                {
                    valorTotal = (horas * precoPorHora) + precoInicial;
                    break;                   
                }                
            }

            return valorTotal;
        }

        public void AdicionarVeiculo()
        {            
            string placa = "";

            Console.WriteLine("Digite a placa do veículo. Apenas números e letras:");
            placa = Console.ReadLine();

            if(ValidarPlaca(placa))
            {
                veiculos.Add(placa);
            }
            else Console.WriteLine("Placa inválida, tente de novo.");
        }

        public void RemoverVeiculo()
        {
            string placa = "";
          
            Console.WriteLine("Digite a placa do veículo para remover:");
            placa = Console.ReadLine();

            // Validação da placa
            if(ValidarPlaca(placa))
            {
                // Verifica se o veículo existe
                if (veiculos.Any(x => x == placa))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    string horasString = Console.ReadLine();

                    decimal valorTotal = QuantidadeDeHoras(horasString);                    
                    
                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");   
            }
            else Console.WriteLine("Placa inválida, tente de novo.");                
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo.ToUpper());
                }                
            }
            else Console.WriteLine("Não há veículos estacionados.");            
        }
    }
}
