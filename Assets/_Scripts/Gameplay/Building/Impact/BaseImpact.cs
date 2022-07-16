using _Scripts.Gameplay.Tile;
using _Scripts.UI.Building.Impact;
using _Scripts.UI.Building.Impact.Impacts;

namespace _Scripts.Gameplay.Building.Impact
{
    public abstract class BaseImpact : IImpact
    {
        private readonly BuildingImpactsViewModel m_impactsViewModel = null;

        protected BuildingViewModel m_building = null;

        public abstract EImpactType ImpactType { get; }
        protected abstract void DoImpact(TileController tileController);

        protected BaseImpact(
            BuildingImpactsViewModel impactsViewModel
        )
        {
            m_impactsViewModel = impactsViewModel;
        }
    }
}
