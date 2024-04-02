using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Models.Entidades;

namespace Trello.Models.RetornoGerais
{
    public class ObterCardsRetorno
    {
        public Card Streamer { get; set; }
        public Card Jogo { get; set; }
        public Card Anime { get; set; }
        public Card Estudo { get; set; }
        public Card Tecnologia { get; set; }
    }
}
