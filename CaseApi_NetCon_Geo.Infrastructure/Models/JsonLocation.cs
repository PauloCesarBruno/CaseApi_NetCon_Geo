namespace CaseApi_NetCon_Geo.Infrastructure.Models;

internal class JsonLocation
{
    public int id { get; set; }
    public string name { get; set; }
    public string status { get; set; }
    public List<Geometry> geometry { get; set; }
}