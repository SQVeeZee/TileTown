using Gameplay.Map;
using JetBrains.Annotations;
using UI.Building.Impact.Impacts.Configs;

namespace UI.Building.Impact.Impacts
{
    [UsedImplicitly]
    public class BuildingImpactsModel : BaseSimpleModel<MapController>
    {
        public BuildingImpactsConfigs ImpactsConfigs { get; set; }
    }
}