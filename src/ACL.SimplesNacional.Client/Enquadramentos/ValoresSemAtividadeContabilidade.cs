namespace ACL.SimplesNacional.Client
{
    public class ValoresSemAtividadeContabilidade : IValoresEnquadramento
    {
        /// <summary>
        /// Número da DASd utilizada na análise
        /// </summary>
        public string Dasd { get; set; }

        /// <summary>
        /// Códigos das atividades declaradas na DASd
        /// </summary>
        public string AtividadesDeclaradas { get; set; }

        /// <summary>
        /// Códigos das atividades declaradas no cadastro municipal
        /// </summary>
        public string AtividadesMunicipio { get; set; }
    }
}
