namespace ACL.SimplesNacional.Client.DiferencaAliquota
{
    public class NFSeDiferencaAliquota
    {
        public decimal Aliquota { get; set; }
        public decimal BaseCalculo { get; set; }
        public decimal IssRetido { get; set; }
        public decimal IssRetidoCalculado { get; set; }
        public string Numero { get; set; }

        public decimal Diferenca => IssRetidoCalculado - IssRetido;
    }
}
