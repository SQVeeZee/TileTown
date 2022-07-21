using System.Collections.Generic;
using _Scripts.Gameplay.Building;
using _Scripts.Gameplay.Building.Builder;
using _Scripts.UI.View;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Building.Builder
{
    public class UIBuildingsBuilderScreen : BaseUIView
    {
        [SerializeField] private Transform m_buildingsElementsRoot = null;

        private Transform m_buildingTransform = null;

        private IBuildingsBuilder BuildingsBuilder { get; set; }
        
        private List<UIBuildingViewModel> m_buildingViewModels = null;
        
        [Inject]
        public void Constructor(
            IBuildingsBuilder buildingsBuilder
            )
        {
            BuildingsBuilder = buildingsBuilder;

            m_buildingViewModels = BuildingsBuilder.AddBuildingIcon(m_buildingsElementsRoot);

            Subscribe();
        }

        public void Initialize(Transform buildingTransform)
        {
            m_buildingTransform = buildingTransform;
        }

        private void Subscribe()
        {
            foreach (var building in m_buildingViewModels)
            {
                building.BuildingClicked += OnBuildingClick;
            }   
        }

        private void UnSubscribe()
        {
            foreach (var building in m_buildingViewModels)
            {
                building.BuildingClicked -= OnBuildingClick;
            }   
        }

        private void OnBuildingClick(EBuildingType buildingType)
        {
            BuildingsBuilder.Build(buildingType, m_buildingTransform);
        }
    }
}
