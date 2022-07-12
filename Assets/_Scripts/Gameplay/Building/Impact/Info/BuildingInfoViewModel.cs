using System;
using Gameplay.Building.Configs;
using Gameplay.Tile;
using UI.Building.Impact;
using UI.Building.Impact.Impacts;
using UI.Building.Impact.Info;
using Zenject;

namespace Gameplay.Building.Impact.Info
{
    public class BuildingInfoViewModel: BaseImpact, IInitializable, IDisposable
    {
        private readonly UIBuildingInfoPanel m_view = null;
        private readonly BuildingInfoModel m_model = null;

        private BaseBuildingConfigs m_baseBuildingConfigs = null;
        
        public override EBuildingImpactType ImpactType => EBuildingImpactType.SHOW_INFO;

        [Inject]
        public BuildingInfoViewModel(
            UIBuildingInfoPanel view,
            BuildingInfoModel model,

            BuildingImpactsViewModel impactsViewModel
        ) : base(impactsViewModel)
        {
            m_view = view;
            m_model = model;
        }

        void IInitializable.Initialize()
        {
            Initialize();

            m_view.CloseButtonPressed += OnCloseButtonPressed;
        }

        void IDisposable.Dispose()
        {
            Dispose();
            
            m_view.CloseButtonPressed -= OnCloseButtonPressed;
        }
        
        protected override void DoImpact(TileController tileController)
        {
            ShowInfo();
        }

        private void ShowInfo()
        {
            m_baseBuildingConfigs = m_building.Configs;
            
            m_view.Initialize(
                m_baseBuildingConfigs.BuildingName,
                m_baseBuildingConfigs.BuildingType.ToString(),
                m_baseBuildingConfigs.BuildingDescription
                );
            
            m_view.DoShow();
        }

        private void OnCloseButtonPressed()
        {
            m_view.DoHide();
        }
    }
}