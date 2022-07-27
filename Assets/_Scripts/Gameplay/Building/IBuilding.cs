using System;
using _Scripts.Gameplay.Building.Configs;
using _Scripts.Gameplay.Building.Impact.Configs;
using _Scripts.UI.Building.Impacts.Configs;
using UniRx;
using UnityEngine;

namespace _Scripts.Gameplay.Building
{
    public interface IBuilding
    {
        event Action<IBuilding> BuildingDestroyed;
        
        IReactiveProperty<Transform> RootTransform { get; }
        
        Transform BuildingTransform { get; set; }
        BaseBuildingData BuildingInfo { get; }
        BuildingImpactsConfigs ImpactsConfigs { get; }
        
        void SetRootTransform(Transform parent);
        void MoveBuilding(Transform targetTransform, bool isAnimated = true);
        void RemoveBuilding();
    }
}