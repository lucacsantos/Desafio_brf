namespace GestaoPessoa.Models
{
    public class GestaoPessoaDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string PessoaCollectionName { get; set; } = null!;
    }
}
