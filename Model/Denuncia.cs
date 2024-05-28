namespace BuyCar.Model
{

    public class Denuncia
    {
        public int Id { get; set; }
        public string? Motivo { get; set; }
        public DateTime Data_Hora { get; set; }
        public string? Status { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int CarroId { get; set; }
        public Carro? Carro { get; set; }
    }

}
