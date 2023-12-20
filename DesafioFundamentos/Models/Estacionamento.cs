namespace DesafioFundamentos.Models
{
    public class Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        private decimal precoInicial = precoInicial;
        private decimal precoPorHora = precoPorHora;
        private List<string> veiculos = [];

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            veiculos.Add(Console.ReadLine());
        }

        public void RemoverVeiculo()
        {
            string placa = "";
          
            Console.WriteLine("Digite a placa do veículo para remover:");
            placa = Console.ReadLine();
           
            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int horas = 0;
                decimal valorTotal = 0;

                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                bool horasValidas = false;

                // conversão e validação da quantidade de horas
                while (!horasValidas)
                {
                    if(!int.TryParse(Console.ReadLine(), out horas))
                    {
                        Console.WriteLine("Valor inválido. Tente novamente.");                    
                    }
                    else
                    {
                        valorTotal = (horas * precoPorHora) + precoInicial;
                        horasValidas = true;
                    }
                }
                
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");            
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }                
            }
            else Console.WriteLine("Não há veículos estacionados.");            
        }
    }
}
