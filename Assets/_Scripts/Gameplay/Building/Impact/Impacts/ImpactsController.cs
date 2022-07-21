using System;
using _Scripts.Gameplay.Tile.Map;
using _Scripts.UI.Building.Impact.Impacts;
using Zenject;

namespace _Scripts.Gameplay.Building.Impact.Impacts
{
    public class ImpactsController : IInitializable, IDisposable
    {
        public event Action<EImpactType> ClickImpact = null;
        
        private readonly BuildingImpactsViewModel m_impactsViewModel;
        private readonly MapClickModule m_mapClickModule = null;
        
        [Inject]
        public ImpactsController(
            BuildingImpactsViewModel impactsViewModel,
            MapClickModule mapClickModule
        )
        {
            m_impactsViewModel = impactsViewModel;

            m_mapClickModule = mapClickModule;
        }

        void IInitializable.Initialize()
        {
            m_impactsViewModel.ImpactClicked += OnImpactClicked;
        }

        void IDisposable.Dispose()
        {
            m_impactsViewModel.ImpactClicked -= OnImpactClicked;
        }

        private void OnImpactClicked(EImpactType impactType)
        {
            ClickImpact?.Invoke(impactType);
        }
    }
}

