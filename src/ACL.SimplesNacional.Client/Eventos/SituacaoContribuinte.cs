using System;

namespace ACL.SimplesNacional.Client.Eventos
{
    public class SituacaoContribuinte
    {
        public SituacaoOpcao MEI { get; set; }
        public SituacaoOpcao SimplesNacional { get; set; }

        public class SituacaoOpcao
        {
            public DateTime DataEfeito { get; set; }
            public bool Optante { get; set; }
        }

    }
}