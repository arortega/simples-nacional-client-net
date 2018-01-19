using System;

namespace ACL.SimplesNacional.Client.Eventos
{
    public class Evento
    {
        public string CnpjBase { get; set; }
        public int Codigo { get; set; }
        public DateTime DataEfeito { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public NaturezaEvento Natureza { get; set; }
        public string NumeroProcessoAdministrativo { get; set; }
        public string NumeroProcessoJudicial { get; set; }
        public string Observacao { get; set; }
        public TipoEvento Tipo { get; set; }
    }
}