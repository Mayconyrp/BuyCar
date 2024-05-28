namespace BuyCar.Model
{
    public class Compra
    {
        public int Id { get; set; }
        public DateTime DataCompra { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int CarroId { get; set; }
        public Carro? Carro { get; set; }
        public decimal PrecoFinal { get; set; }

        public Compra()
        {
            DataCompra = DateTime.Now;
        }
    }
}
