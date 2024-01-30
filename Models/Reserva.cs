namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public class CapacidadeExcedida : Exception
        {
            public CapacidadeExcedida() : base("A capacidade da suíte foi excedida") { }
        }


        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                
                throw new CapacidadeExcedida();
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            
            int totalHospedes = Hospedes.Count;
            return totalHospedes;
        }

        public decimal CalcularValorDiaria()
        {
            
            
            decimal valor = 0;

           

            valor = DiasReservados * Suite.ValorDiaria;

            
            if (DiasReservados >= 10)
            {
                decimal desconto = 0.9m;
                valor = valor * desconto;
            }

            return valor;
        }
    }
}