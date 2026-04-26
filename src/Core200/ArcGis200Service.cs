using Esri.ArcGISRuntime;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;

namespace Core200;

public sealed class ArcGis200Service : IGisService
{
    private const int PointCount = 10_000;
    private readonly List<MapPoint> _sourcePoints = new(PointCount);
    private readonly List<Graphic> _graphicPool = new();
    private GraphicsOverlay? _overlay;

    public void Initialize()
    {
        var apiKey = Environment.GetEnvironmentVariable("ARCGIS_API_KEY");
        var license = Environment.GetEnvironmentVariable("ARCGIS200_LICENSE_KEY")
            ?? Environment.GetEnvironmentVariable("ARCGIS_LICENSE_KEY");

        if (!string.IsNullOrWhiteSpace(apiKey))
            ArcGISRuntimeEnvironment.ApiKey = apiKey;

        if (!string.IsNullOrWhiteSpace(license))
            ArcGISRuntimeEnvironment.SetLicense(license);

        if (_sourcePoints.Count == 0)
        {
            for (var i = 0; i < PointCount; i++)
            {
                var x = -96.7970 + (i % 100) * 0.0001;
                var y = 32.7767 + (i / 100) * 0.0001;
                _sourcePoints.Add(new MapPoint(x, y, SpatialReferences.Wgs84));
            }
        }

        _overlay = new GraphicsOverlay();
    }

    public void Project10kPoints()
    {
        var target = SpatialReferences.WebMercator;
        for (var i = 0; i < _sourcePoints.Count; i++)
            _ = GeometryEngine.Project(_sourcePoints[i], target);
    }

    public void AddRemoveGraphics(int count)
    {
        var overlay = _overlay ?? throw new InvalidOperationException("Service not initialized.");
        overlay.Graphics.Clear();
        _graphicPool.Clear();

        var symbol = new SimpleMarkerSymbol(SimpleMarkerSymbolStyle.Circle, System.Drawing.Color.Orange, 10);

        for (var i = 0; i < count; i++)
        {
            var point = _sourcePoints[i % _sourcePoints.Count];
            var graphic = new Graphic(point, symbol);
            _graphicPool.Add(graphic);
            overlay.Graphics.Add(graphic);
        }

        overlay.Graphics.Clear();
        _graphicPool.Clear();
    }
}
