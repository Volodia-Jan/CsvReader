using System.Globalization;
using CsvReader.Core.Models;
using CsvReader.Core.ServiceContracts;
using Microsoft.VisualBasic.FileIO;

namespace CsvReader.Core.Services;
public class GasService : IGasService
{
    public List<Gas> UploadFromCsvFile(string filename, string delimiters, bool hasHeader = true)
    {
        using var textParser = new TextFieldParser(filename);
        textParser.SetDelimiters(delimiters);
        var gasList = new List<Gas>();

        if (hasHeader)
            textParser.ReadLine();

        while (!textParser.EndOfData)
        {
            var fields = textParser.ReadFields();
            if (fields == null)
                continue;
            if (fields.Any(string.IsNullOrEmpty))
                continue;
            
            gasList.Add(new Gas
            {
                Id = long.Parse(fields[0]),
                SiteName = fields[1],
                GasBrand = fields[2],
                City = fields[3],
                ClusterMediaPrice = double.TryParse(fields[4], CultureInfo.InvariantCulture, out var mediaPrice) ? mediaPrice : null,
                ClientMarketPrice = double.TryParse(fields[5], CultureInfo.InvariantCulture, out var clientPrice) ? clientPrice : null,
                Latitude = double.TryParse(fields[6], CultureInfo.InvariantCulture, out var latitude) ? latitude : null,
                Longitude = double.TryParse(fields[7], CultureInfo.InvariantCulture, out var longitude) ? longitude : null,
            });
        }

        return gasList;
    }
}
