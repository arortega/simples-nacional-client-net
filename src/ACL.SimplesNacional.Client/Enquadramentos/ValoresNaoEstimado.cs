namespace ACL.SimplesNacional.Client
{
    public class ValoresNaoEstimado : IValoresEnquadramento
    {
        /// <summary>
        /// Número da DASd utilizada na análise
        /// </summary>
        public string Dasd { get; set; }

        /// <summary>
        /// Valor do ISS declarado na DASd
        /// </summary>
        public decimal IssDeclarado { get; set; }
    }
}
