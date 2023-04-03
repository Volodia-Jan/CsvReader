using CsvReader.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace CsvReader.Web.Controllers;

[Route("/")]
[Route(("api/v1/[controller]"))]
public class GasController : Controller
{
    private readonly IGasService _gisService;

    public GasController(IGasService gisService)
    {
        _gisService = gisService;
    }

    [HttpGet]
    public IActionResult GetAllGas() =>
        View("GasView", _gisService.UploadFromCsvFile("wwwroot/test_data.csv", ";"));
}