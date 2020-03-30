namespace SimpleBlazorServer.Queries
{
    public class BaseQuery
    {
        public BaseQuery()
        {
            Skip = 0;
            Take = 50;
        }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
