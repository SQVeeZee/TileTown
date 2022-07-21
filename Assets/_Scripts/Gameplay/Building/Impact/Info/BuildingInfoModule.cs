using System;
using _Scripts.Gameplay.Building.Configs;
using JetBrains.Annotations;
using Zenject;

namespace _Scripts.Gameplay.Building.Impact.Info
{
    [UsedImplicitly]
    public class BuildingInfoModule: IInitializable, IDisposable
    {
        private readonly UIBuildingInfoPanel m_buildingInfoPanel = null;
        
        [Inject]
        public BuildingInfoModule(
            UIBuildingInfoPanel buildingInfoPanel
            )
        {
            m_buildingInfoPanel = buildingInfoPanel;
        }

        void IInitializable.Initialize()
        {
            m_buildingInfoPanel.CloseButtonPressed += OnCloseButtonPressed;
        }

        void IDisposable.Dispose()
        {
            m_buildingInfoPanel.CloseButtonPressed -= OnCloseButtonPressed;
        }

        public void ShowInfo(BaseBuildingData buildingData)
        {
            m_buildingInfoPanel.Initialize(
                buildingData.BuildingName,
                buildingData.BuildingType.ToString(),
                buildingData.BuildingDescription
            );
            
            m_buildingInfoPanel.DoShow();
        }
        
        private void OnCloseButtonPressed()
        {
            HideInfo();
        }

        private void HideInfo()
        {
            m_buildingInfoPanel.DoHide();
        }
    }
}
