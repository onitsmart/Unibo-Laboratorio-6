﻿using Laboratorio6.Web.Infrastructure;
using System.Collections.Generic;

namespace Laboratorio6.Web.Features.Esercizio
{
    [TypeScriptModule("Features.Esercizio.Server")]
    public class IndexViewModel
    {
        public IEnumerable<MessaggioViewModel> Messaggi { get; set; }

        public IndexViewModel()
        {
            this.Messaggi = new List<MessaggioViewModel>()
            {
                new MessaggioViewModel
                {
                    Id = 0,
                    Testo = "Messaggio 1",
                    DaMostrare = true,
                    Errore = false,
                    ColoreSfondo = "white"
                },
                new MessaggioViewModel
                {
                    Id = 1,
                    Testo = "Messaggio 2",
                    DaMostrare = true,
                    Errore = true,
                    ColoreSfondo = "white"
                },
                new MessaggioViewModel
                {
                    Id = 2,
                    Testo = "Messaggio 3",
                    DaMostrare = true,
                    Errore = true,
                    ColoreSfondo = "black"
                },
                new MessaggioViewModel
                {
                    Id = 3,
                    Testo = "Messaggio 4",
                    DaMostrare = false,
                    Errore = true,
                    ColoreSfondo = "white"
                }
            };
        }

        public string ToJson()
        {
            return Infrastructure.JsonSerializer.ToJsonCamelCase(this);
        }
    }

    [TypeScriptModule("Esercizio.Server")]
    public class MessaggioViewModel
    {
        public int Id { get; set; }
        public string Testo { get; set; }
        public bool DaMostrare { get; set; }
        public bool Errore { get; set; }

        public string ColoreSfondo { get; set; }
    }
}
