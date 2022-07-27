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
        [SerializeField] private Transform _buildingsElementsRoot = null;
        
        private IBuildingsBuilder BuildingsBuilder { get; set; }
        private IUIBuildingsBuilderModule _buildingsIconsBuilderModule = null;

        private List<UIBuildingView> _buildingViewModels = new List<UIBuildingView>();

        [Inject]
        public void Constructor(
            IBuildingsBuilder buildingsBuilder,
            IUIBuildingsBuilderModule iuiBuildingsBuilderModule
        )
        {
            BuildingsBuilder = buildingsBuilder;

            _buildingsIconsBuilderModule = iuiBuildingsBuilderModule;
        }

        public override void Initialize()
        {
            _buildingViewModels = _buildingsIconsBuilderModule.CreateAndGetBuildingIcons(_buildingsElementsRoot);
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
            foreach (var building in _buildingViewModels)
            {
                building.ViewClicked += OnBuildingClick;
            }   
        }

        private void UnSubscribe()
        {
            foreach (var building in _buildingViewModels)
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
