namespace Rate_LimitingMiddleware.Middlewares
{
    public class ClientStatistics
    {
        public DateTime LastSuccessfulResponseTime { get; set; }
        public int NumberOfRequestsCompletedSuccessfully { get; set; }
    }
}