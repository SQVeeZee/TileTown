using System;
using System.Collections.Generic;
using Gameplay.Building;
using UnityEngine;

namespace UI.Building.Impact.Builder
{
    public class UIBuildingsBuilderPanel : BaseUIView
    {
        public event Action<EBuildingType> BuildingChose = null; 
        
        [SerializeField] private Transform m_buildingsElementsRoot = null;

        public Transform GridRoot => m_buildingsElementsRoot;
        
        private Dictionary<EBuildingType, BuildingViewModel> m_buildingsByBuildingType = 
            new Dictionary<EBuildingType, BuildingViewModel>();
        
        private void OnBuildingChose(BuildingViewModel viewModel)
        {
            // BuildingChose?.Invoke(viewModel.BuildingType);
        }
    }
}
