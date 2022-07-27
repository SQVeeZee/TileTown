using System;
using _Scripts.UI.Building.Impacts.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Building.Impact
{
    public interface IUIBuildingImpact: IPoolable<BuildingImpactConfigs, Transform>
    {
        event Action<EImpactType> ImpactClicked;
    }
}