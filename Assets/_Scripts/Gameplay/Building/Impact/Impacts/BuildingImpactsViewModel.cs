using System;
using System.Collections.Generic;
using _Scripts.Gameplay.Building.Impacts;
using _Scripts.UI.Building.Impacts.Builder;
using _Scripts.UI.Building.Impacts.Configs;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Building.Impacts
{
    public interface IUIBuildingImpacts
    {
        event Action<EImpactType> ImpactClicked;

        ReactiveProperty<BuildingImpactsConfigs> BuildingImpactsConfigs { get; }
        
        void CreateImpacts(Transform parent);
        void SetBuildingImpactsConfigs(BuildingImpactsConfigs impactsConfigs);
    }
    
    [UsedImplicitly]
    public class UIBuildingImpactsViewModel: IUIBuildingImpacts, IDisposable
    {
        public event Action<EImpactType> ImpactClicked = null;

        public ReactiveProperty<BuildingImpactsConfigs> BuildingImpactsConfigs { get; } = 
            new ReactiveProperty<BuildingImpactsConfigs>();
        
        private readonly UIBuildingImpactsBuilder m_buildingImpactsBuilder = null;
        
        private List<IUIBuildingImpact> m_uiBuildingImpacts = new List<IUIBuildingImpact>();
        
        [Inject]
        public UIBuildingImpactsViewModel(
            UIBuildingImpactsBuilder buildingImpactsBuilder
        )
        {
            m_buildingImpactsBuilder = buildingImpactsBuilder;
        }

        void IUIBuildingImpacts.CreateImpacts(Transform parent)
        {
            m_uiBuildingImpacts = m_buildingImpactsBuilder.FillActionPanel(BuildingImpactsConfigs.Value, parent);
            
            foreach (var impact in m_uiBuildingImpacts)
            {
                impact.ImpactClicked += OnImpactClicked;
            }
        }

        void IDisposable.Dispose()
        {
            foreach (var impact in m_uiBuildingImpacts)
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