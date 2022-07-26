using System.Collections.Generic;
using _Scripts.Gameplay.Building;
using _Scripts.Gameplay.Building.Builder;
using _Scripts.UI.Screen;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Building.Builder
{
    public class UIBuildingsBuilderScreen : BaseScreen
    {
        [SerializeField] private Transform m_buildingsElementsRoot = null;
        
        private IBuildingsBuilder BuildingsBuilder { get; set; }
        private IUIBuildingsBuilderModule m_buildingsIconsBuilderModule = null;

        private List<UIBuildingView> m_buildingViewModels = new List<UIBuildingView>();

        [Inject]
        public void Constructor(
            IBuildingsBuilder buildingsBuilder,
            IUIBuildingsBuilderModule uiBuildingsBuilderModule
        )
        {
            BuildingsBuilder = buildingsBuilder;

            m_buildingsIconsBuilderModule = uiBuildingsBuilderModule;
        }

        public override void Initialize()
        {
            m_buildingViewModels = m_buildingsIconsBuilderModule.CreateAndGetBuildingIcons(m_buildingsElementsRoot);
        }
        
        public override void Dispose()
        {
            
        }

        protected override void OnAfterScreenShow()
        {
            base.OnAfterScreenShow();
            
            Subscribe();
        }

        protected override void OnBeforeScreenHide()
        {
            base.OnBeforeScreenHide();
            
            UnSubscribe();
        }

        private void Subscribe()
        {
            foreach (var building in m_buildingViewModels)
            {
                building.ViewClicked += OnBuildingClick;
            }   
        }

        private void UnSubscribe()
        {
            foreach (var building in m_buildingViewModels)
            {
                building.ViewClicked -= OnBuildingClick;
            }   
        }

        private void OnBuildingClick(EBuildingType buildingType)
        {
            BuildingsBuilder.CreateBuilding(buildingType);

            HideThisScreen();
        }
    }
}
