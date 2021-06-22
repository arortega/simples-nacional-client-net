using System;

namespace ACL.SimplesNacional.Client
{
    public class ResumoMensagemIntegracao
    {
        public string De { get; set; }
        public string Para { get; set; }
        public string Assunto { get; set; }
        public int Categoria { get; set; }
        public DateTime DataEnvio { get; set; }
        public DateTime? DataLeitura { get; set; }
        public bool Lida => DataLeitura.HasValue;
        public bool PossuiAnexo { get; set; }
    }
}