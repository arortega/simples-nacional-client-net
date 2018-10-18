using System;

namespace ACL.SimplesNacional.Client
{
    /// <summary>
    /// Resultado da análise de enquadramento
    /// </summary>
    /// <typeparam name="T">Tipo da análise</typeparam>
    public class ResultadoAnalise<T>
    {
        /// <summary>
        /// Ano da competência analisada
        /// </summary>
        public int Ano { get; set; }

        /// <summary>
        /// CNPJ do contribuinte
        /// </summary>
        public string Cnpj { get; set; }

        /// <summary>
        /// Data de criação da divergência
        /// </summary>
        public DateTime DataCriacao { get; set; }

        /// <summary>
        /// Mês da competência analisada
        /// </summary>
        public int Mes { get; set; }

        /// <summary>
        /// Potencial de arrecadação para a competência
        /// </summary>
        public decimal Potencial { get; set; }

        /// <summary>
        /// Dados sobre a análise
        /// </summary>
        public T Valores { get; set; }
    }
}
