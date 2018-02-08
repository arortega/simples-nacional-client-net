using System;

namespace ACL.SimplesNacional.Client.Eventos
{
    /// <summary>
    /// Retorno da API de consulta de eventos
    /// </summary>
    public class Evento
    {
        /// <summary>
        /// CNPJ base
        /// </summary>
        public string CnpjBase { get; set; }

        /// <summary>
        /// C�digo do evento
        /// </summary>
        public int Codigo { get; set; }

        /// <summary>
        /// Data de efeito
        /// </summary>
        public DateTime DataEfeito { get; set; }

        /// <summary>
        /// Data da ocorr�ncia
        /// </summary>
        public DateTime DataOcorrencia { get; set; }

        /// <summary>
        /// Evento gerado pelo arquivo de MEI
        /// </summary>
        public bool MEI { get; set; }

        /// <summary>
        /// Natureza do evento
        /// </summary>
        public NaturezaEvento Natureza { get; set; }

        /// <summary>
        /// N�mero do processo administrativo
        /// </summary>
        public string NumeroProcessoAdministrativo { get; set; }

        /// <summary>
        /// N�mero do processo judicial
        /// </summary>
        public string NumeroProcessoJudicial { get; set; }

        /// <summary>
        /// Observa��es do evento
        /// </summary>
        public string Observacao { get; set; }

        /// <summary>
        /// Tipo do evento
        /// </summary>
        public TipoEvento Tipo { get; set; }
    }
}