﻿using Trello.Models.Enums;

namespace Trello.Models.Entidades
{
    public class Card
    {
        public Card()
        {
            Comentarios = new List<Comentario>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public TipoAssunto Assunto { get; set; }
        public string Categoria { get; set; }
        public EtiquetasCard Etiqueta { get; set; }
        public DateTime DataPublicacao { get; set; }
        public DateTime DataEntrega { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}
