using System;

namespace ACL.SimplesNacional.Client
{
    public class ValoresSemNFSe : IValoresEnquadramento
    {
        /// <summary>
        /// Número da DASd utilizada na análise
        /// </summary>
        public string Dasd { get; set; }

        /// <summary>
        /// Data de autorização do contribuinte no cadastro municipal
        /// </summary>
        public DateTime? DataAutorizacao { get; set; }
    }
}
