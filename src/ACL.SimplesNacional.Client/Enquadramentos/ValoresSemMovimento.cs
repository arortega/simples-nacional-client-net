using System;

namespace ACL.SimplesNacional.Client
{
    public class ValoresSemMovimento : IValoresEnquadramento
    {
        /// <summary>
        /// Data de autorização do contribuinte no cadastro municipal
        /// </summary>
        public DateTime? DataAutorizacao { get; set; }
    }
}
