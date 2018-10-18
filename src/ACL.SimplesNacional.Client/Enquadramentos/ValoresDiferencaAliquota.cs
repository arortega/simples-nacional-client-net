using System.Collections.Generic;

namespace ACL.SimplesNacional.Client
{
    /// <summary>
    /// Informações da análise de diferença de alíquota
    /// </summary>
    public class ValoresDiferencaAliquota : IValoresEnquadramento
    {
        /// <summary>
        /// Alíquota calculada de acordo com a receita declarada
        /// </summary>
        public decimal Aliquota { get; set; }

        /// <summary>
        /// Número da DASd utilizada na análise
        /// </summary>
        public string Dasd { get; set; }

        /// <summary>
        /// Lista de NFSes com divergência de alíquota declarada
        /// </summary>
        public IEnumerable<NFSeDiferencaAliquota> NFSes { get; set; }

        /// <summary>
        /// Receita bruta dos últimos 12 meses utilizada para cálculo da alíquota
        /// </summary>
        public decimal ReceitaBruta12Meses { get; set; }
    }
}
