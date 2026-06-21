namespace MOVIFY.Services
{
    public interface IReportService
    {
        byte[] GenerateMoviesReport(); 
        byte[] GenerateCategoriesReport();
        byte[] GenerateDirectorsReport();
        byte[] GenerateAnalyticsReport();
    }
}