using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Buffet.Models.Buffet.Evento;

namespace Buffet.Models.Buffet.Local
{
    public class LocalEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        // [InverseProperty("Local")]
        // public List<EventoEntity> Eventos { get; set; }
    }
}