namespace BuyCar.Model
{
    public class Carro
    {
        public int Id { get; set; }
        public string? Foto { get; set; }
        public string? Modelo { get; set; }
        public string? Marca { get; set; }
        public string? Cor { get; set; }
        public string? Descricao { get; set; }
        public string? Placa { get; set; }
        public string? Preco { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }


    }
}
