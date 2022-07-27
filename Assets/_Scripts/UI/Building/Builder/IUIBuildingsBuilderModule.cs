using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.UI.Building.Builder
{
    public interface IUIBuildingsBuilderModule
    {
        List<UIBuildingView> CreateAndGetBuildingIcons(Transform parentTransform);
    }
}