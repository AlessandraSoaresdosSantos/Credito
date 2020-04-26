namespace Credito.Dominio
{
    public class Constantes
    {
        public const double CREDITO_DIRETO = 0.02f;
        public const double CREDITO_CONSIGNADO = 0.01f;
        public const double CREDITO_PESSOA_JURIDICA = 0.05f;
        public const double CREDITO_PESSOA_FISICA = 0.03f;
        public const double CREDITO_IMOBILIARIO = 0.09f;
        public const double VALOR_MAXIMO_LIBERADO = 1000000.00f;
        public const int QTDE_PARCELA_MAXIMA = 72;
        public const int QTDE_PARCELA_MINIMA = 5;
        public const double CREDITO_PESSOA_JURIDICA_VALOR_MINIMO = 15000.00f;
        public const int QTDE_DIAS_MINIMO_VENCIMENTO = 15;
        public const int QTDE_DIAS_MAXIMO_VENCIMENTO = 40;

        public const string VALOR_MAXIMO_EMPRESTIMO = "O valor máximo a ser liberado para qualquer tipo de empréstimo é de R$ 1.000.000,00";
        public const string QUANTIDADE_MAXIMA_PARCELAS = "A quantidade de parcelas máxima é de 72 vezes";
        public const string QUANTIDADE_MINIMA_PARCELAS = "A quantidade de parcelas mínima é de 5 vezes";
        public const string PESSOA_JURIDICA_VALOR_MINIMO_LIBERADO = "Para o crédito de pessoa jurídica, o valor mínimo a ser liberado é de R$ 15.000,00";
        public const string DATA_VENCIMENTO_MINIMO_15_DIAS = "A data do primeiro vencimento sempre será - no mínimo de 15 dias";
        public const string DATA_VENCIMENTO_MAXIMO_40_DIAS = "A data do primeiro vencimento será no máximo de 40 dias";
      
       
    }
}
