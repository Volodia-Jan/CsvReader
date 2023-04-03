namespace CsvReader.Core.Models;
public class Gas
{
    public long Id { get; set; }
    public string SiteName { get; set; }
    public string GasBrand { get; set; }
    public string City { get; set; }
    public double? ClusterMediaPrice { get; set; }
    public double? ClientMarketPrice { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}
