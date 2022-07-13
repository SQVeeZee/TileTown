using System;
using _Scripts.Gameplay.Building.Configs;
using UI.Building.Impact.Info;
using Zenject;

namespace Gameplay.Building.Impact.Info
{
    public class BuildingInfoViewModel: IInitializable, IDisposable
    {
        private readonly UIBuildingInfoPanel m_view = null;
        private readonly BuildingInfoModel m_model = null;
        private readonly ImpactsController m_impacts = null;
        
        [Inject]
        public BuildingInfoViewModel(
            UIBuildingInfoPanel view,
            BuildingInfoModel model,
            
            ImpactsController impactsController
        )
        {
            m_view = view;
            m_model = model;

            m_impacts = impactsController;
        }

        void IInitializable.Initialize()
        {
            m_view.CloseButtonPressed += OnCloseButtonPressed;
            m_impacts.ShowImpactClicked += OnShowImpactClicked;
        }

        void IDisposable.Dispose()
        {
            m_view.CloseButtonPressed -= OnCloseButtonPressed;
            
            m_impacts.ShowImpactClicked -= OnShowImpactClicked;
        }

        private void OnShowImpactClicked(BaseBuildingConfigs baseBuildingConfigs)
        {
            ShowInfo(baseBuildingConfigs);
        }

        private void ShowInfo(BaseBuildingConfigs baseBuildingConfigs)
        {
            m_view.Initialize(
                baseBuildingConfigs.BuildingName,
                baseBuildingConfigs.BuildingType.ToString(),
                baseBuildingConfigs.BuildingDescription
                );
            
            m_view.DoShow();
        }

        private void OnCloseButtonPressed()
        {
            m_view.DoHide();
        }
    }
}