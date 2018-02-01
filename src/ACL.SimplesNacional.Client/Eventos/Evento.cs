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
        /// Código do evento
        /// </summary>
        public int Codigo { get; set; }

        /// <summary>
        /// Data de efeito
        /// </summary>
        public DateTime DataEfeito { get; set; }

        /// <summary>
        /// Data da ocorrência
        /// </summary>
        public DateTime DataOcorrencia { get; set; }

        /// <summary>
        /// Natureza do evento
        /// </summary>
        public NaturezaEvento Natureza { get; set; }

        /// <summary>
        /// Número do processo administrativo
        /// </summary>
        public string NumeroProcessoAdministrativo { get; set; }

        /// <summary>
        /// Número do processo judicial
        /// </summary>
        public string NumeroProcessoJudicial { get; set; }

        /// <summary>
        /// Observações do evento
        /// </summary>
        public string Observacao { get; set; }

        /// <summary>
        /// Tipo do evento
        /// </summary>
        public TipoEvento Tipo { get; set; }
    }
}