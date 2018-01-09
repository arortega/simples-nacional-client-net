namespace ACL.SimplesNacional.Client
{
    public class ResultadoAnalise<T>
    {
        public int Ano { get; set; }
        public string Cnpj { get; set; }
        public int Mes { get; set; }
        public decimal Potencial { get; set; }
        public T Valores { get; set; }
    }
}
