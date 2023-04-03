using CsvReader.Core.Models;

namespace CsvReader.Core.ServiceContracts;
public interface IGasService
{
    /// <summary>
    /// Parsing data from CSV file into list of Gas class
    /// </summary>
    /// <param name="filename">File name to parse</param>
    /// <param name="delimiters">Separator in CSV file</param>
    /// <param name="hasHeader">Does file contain headers</param>
    /// <returns>List of Gas class parsed from CSV file</returns>
    List<Gas> UploadFromCsvFile(string filename, string delimiters, bool hasHeader = true);
}
