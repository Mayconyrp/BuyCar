using System.Collections.ObjectModel;

namespace BuyCar.Model
{
    public class Usuario
    {
        public Usuario()
        {
            Carros =  new Collection<Carro>();
            Denuncias= new Collection<Denuncia>();
            Compras = new Collection<Compra>();
        }
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public int? Senha { get; set; }
        public bool Premium { get; set;}
            
        public ICollection<Carro> Carros { get; set; }
        public ICollection<Denuncia> Denuncias { get; set; }
        public ICollection<Compra> Compras { get; set; }



    }
}
