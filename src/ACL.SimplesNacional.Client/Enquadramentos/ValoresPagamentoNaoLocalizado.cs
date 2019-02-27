namespace ACL.SimplesNacional.Client
{
    public class ValoresPagamentoNaoLocalizado : IValoresEnquadramento
    {
        /// <summary>
        /// Número da DASd utilizada na análise
        /// </summary>
        public string Dasd { get; set; }

        /// <summary>
        /// Número do PAG utilizado para resolver o enquadramento
        /// </summary>
        public string NumeroDasPag { get; set; }

        /// <summary>
        /// Número da guia devida
        /// </summary>
        public string NumeroGuia { get; set; }

        /// <summary>
        /// Número do parcelamento utilizado para resolver o enquadramento
        /// </summary>
        public int? NumeroParcelamento { get; set; }

        /// <summary>
        /// Valor da guia devida
        /// </summary>
        public decimal? ValorGuia { get; set; }

        /// <summary>
        /// Valor do ISS declarado para a competência
        /// </summary>
        public decimal ValorISS { get; set; }
    }
}
