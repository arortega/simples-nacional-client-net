namespace ACL.SimplesNacional.Client
{
    public class ValoresDiferencaBaseCalculoRetido : IValoresEnquadramento
    {
        /// <summary>
        /// Número da DASd utilizada na análise
        /// </summary>
        public string Dasd { get; set; }

        /// <summary>
        /// Valor da base de cálculo declarada na DASd
        /// </summary>
        public decimal BaseCalculoDasd { get; set; }

        /// <summary>
        /// Valor do somatório de bases de cálculos das NFSes para a competência
        /// </summary>
        public decimal BaseCalculoNFSe { get; set; }
    }
}
