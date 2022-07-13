using System;
using _Scripts.Gameplay.Building.Configs;
using _Scripts.UI.Building.Impact.Impacts;
using Zenject;

namespace _Scripts.Gameplay.Building.Impact.Impacts
{
    public class ImpactsController : IInitializable, IDisposable
    {
        public event Action<BaseBuildingConfigs> ShowImpactClicked = null;
        public event Action<BuildingViewModel> RemoveImpactClicked = null;
        public event Action MoveImpactClicked = null;

        private readonly BuildingImpactsViewModel m_impactsViewModel;

        [Inject]
        public ImpactsController(
            BuildingImpactsViewModel impactsViewModel
        )
        {
            m_impactsViewModel = impactsViewModel;
        }

        void IInitializable.Initialize()
        {
            m_impactsViewModel.ImpactClicked += OnImpactClicked;
        }

        void IDisposable.Dispose()
        {
            m_impactsViewModel.ImpactClicked -= OnImpactClicked;
        }

        public void EnableImpactsView(BuildingViewModel selectedBuilding)
        {
            m_impactsViewModel.EnableBuildingImpactsView(selectedBuilding);
        }

        private void OnImpactClicked(EBuildingImpactType impactType, BuildingViewModel building)
        {
            switch (impactType)
            {
                case EBuildingImpactType.REMOVE:
                    RemoveBuilding(building);
                    break;
                case EBuildingImpactType.MOVE:
                    MoveBuilding();
                    break;
                case EBuildingImpactType.SHOW_INFO:
                    ShowInfo(building);
                    break;
            }
        }

        private void ShowInfo(BuildingViewModel building)
        {
            ShowImpactClicked?.Invoke(building.Configs);
        }

        private void RemoveBuilding(BuildingViewModel building)
        {
            building.Remove();
        }

        private void MoveBuilding()
        {
            MoveImpactClicked?.Invoke();
        }
    }
}

