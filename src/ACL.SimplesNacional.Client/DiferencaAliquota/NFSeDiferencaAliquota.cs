namespace ACL.SimplesNacional.Client.DiferencaAliquota
{
    /// <summary>
    /// Informações sobre NFSes enquadradas por diferença de alíquota
    /// </summary>
    public class NFSeDiferencaAliquota
    {
        /// <summary>
        /// Alíquota declarada
        /// </summary>
        public decimal Aliquota { get; set; }

        /// <summary>
        /// Base de cálculo declarada
        /// </summary>
        public decimal BaseCalculo { get; set; }

        /// <summary>
        /// Valor do ISS retido declarado
        /// </summary>
        public decimal IssRetido { get; set; }

        /// <summary>
        /// Valor do ISS retido corrigido pela receita do contribuinte
        /// </summary>
        public decimal IssRetidoCalculado { get; set; }

        /// <summary>
        /// Número da NFSe
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Valor devido pelo contribuinte
        /// </summary>
        public decimal Diferenca => IssRetidoCalculado - IssRetido;
    }
}
