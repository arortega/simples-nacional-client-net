using System.Collections.Generic;

namespace ACL.SimplesNacional.Client.DiferencaAliquota
{
    public class ValoresDiferencaAliquota
    {
        public decimal Aliquota { get; set; }
        public string Dasd { get; set; }
        public IEnumerable<NFSeDiferencaAliquota> NFSes { get; set; }
        public decimal ReceitaBruta12Meses { get; set; }
    }
}
