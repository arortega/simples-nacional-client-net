namespace ACL.SimplesNacional.Client.Sublimites
{
    /// <summary>
    /// Retorno da API de análise de sublimites
    /// </summary>
    public class AnaliseSublimite
    {
        /// <summary>
        /// Ano da competência responsável pelo enquadramento
        /// </summary>
        public int Ano { get; set; }

        /// <summary>
        /// Cnpj do contribuinte enquadrado
        /// </summary>
        public string Cnpj { get; set; }

        /// <summary>
        /// Mês da competência responsável pelo enquadramento
        /// </summary>
        public int Mes { get; set; }

        /// <summary>
        /// Valor do sublimite estadual ou nacional
        /// </summary>
        public double Sublimite { get; set; }

        /// <summary>
        /// Receita bruta do ano-calendário para o mercado externo
        /// </summary>
        public double RBAExterno { get; set; }

        /// <summary>
        /// Receita bruta do ano-calendário para o mercado interno
        /// </summary>
        public double RBAInterno { get; set; }
    }
}