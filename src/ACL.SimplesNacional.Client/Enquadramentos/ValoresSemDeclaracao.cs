namespace ACL.SimplesNacional.Client
{
    public class ValoresSemDeclaracao : IValoresEnquadramento
    {
        /// <summary>
        /// Número da DASd utilizada na análise
        /// </summary>
        public string Dasd { get; set; }

        /// <summary>
        /// Número de NFSes emitidas na competência
        /// </summary>
        public int TotalNFSes { get; set; }
    }
}
