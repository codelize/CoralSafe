namespace CoralSafe.Models
{
    public class FeedView
    {
        public IEnumerable<Produto> Produtos { get; set; }
        public IEnumerable<Campanha> Campanhas { get; set; }

    }
}
