namespace GestaoDeProdutos
{
    public class produtoTapecaria
    {
        int id;

        enum tipoTapecaria
        {
            tapete, cortina, estofado, outros
        };

        DateTime dataEntrada;
        
        double area;
        
        decimal precoMetroQuadrado;
        
        bool entregarAposServico;

        string detalhes;

    }
}