using System;
using _Scripts.Gameplay.Building.Impact.Configs;
using _Scripts.UI.Building.Impact;
using UniRx;
using UnityEngine;

namespace _Scripts.UI.Building.Impacts
{
    public interface IUIBuildingImpacts
    {
        event Action<EImpactType> ImpactClicked;

        ReactiveProperty<BuildingImpactsConfigs> BuildingImpactsConfigs { get; }
        
        void CreateImpacts(Transform parent);
        void ResetImpacts();
        void SetBuildingImpactsConfigs(BuildingImpactsConfigs impactsConfigs);
    }
}