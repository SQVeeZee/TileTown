using System;
using System.Collections.Generic;
using _Scripts.Gameplay.Building.Impact.Configs;
using _Scripts.UI.Building.Builder;
using _Scripts.UI.Building.Impact;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Building.Impacts
{
    [UsedImplicitly]
    public class IuiBuildingImpactsViewModel: IUIBuildingImpacts, IDisposable
    {
        public event Action<EImpactType> ImpactClicked = null;

        public ReactiveProperty<BuildingImpactsConfigs> BuildingImpactsConfigs { get; } = 
            new ReactiveProperty<BuildingImpactsConfigs>();
        
        private readonly UIBuildingImpactsBuilder _buildingImpactsBuilder = null;
        
        private List<IUIBuildingImpact> _uiBuildingImpacts = new List<IUIBuildingImpact>();
        
        [Inject]
        public IuiBuildingImpactsViewModel(
            UIBuildingImpactsBuilder buildingImpactsBuilder
        )
        {
            _buildingImpactsBuilder = buildingImpactsBuilder;
        }

        void IUIBuildingImpacts.CreateImpacts(Transform parent)
        {
            _uiBuildingImpacts = _buildingImpactsBuilder.FillActionPanel(BuildingImpactsConfigs.Value, parent);
            
            foreach (var impact in _uiBuildingImpacts)
            {
                impact.ImpactClicked += OnImpactClicked;
            }
        }

        void IUIBuildingImpacts.ResetImpacts()
        {
            _buildingImpactsBuilder.DeSpawn();
        }

        void IDisposable.Dispose()
        {
            foreach (var impact in _uiBuildingImpacts)
            {
                impact.ImpactClicked -= OnImpactClicked;
            }
        }
        
        void IUIBuildingImpacts.SetBuildingImpactsConfigs(BuildingImpactsConfigs impactsConfigs)
        {
            BuildingImpactsConfigs.Value = impactsConfigs;
        }

        private void OnImpactClicked(EImpactType impactType)
        {
            ImpactClicked?.Invoke(impactType);
        }
    }
}