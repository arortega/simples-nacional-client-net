namespace ACL.SimplesNacional.Client
{
    public class ValoresIssDeclaradoMenorQueEstimativa : IValoresEnquadramento
    {
        /// <summary>
        /// Número da DASd utilizada na análise
        /// </summary>
        public string Dasd { get; set; }

        /// <summary>
        /// Valor do ISS fixo declarado na DASd
        /// </summary>
        public decimal IssDeclarado { get; set; }

        /// <summary>
        /// Valor do ISS no cadastro municipal do contribuinte
        /// </summary>
        public decimal IssEstimado { get; set; }
    }
}
