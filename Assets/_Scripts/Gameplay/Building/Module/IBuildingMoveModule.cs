using UnityEngine;

namespace _Scripts.Gameplay.Building.Impacts.Move
{
    public interface IBuildingMoveModule
    {
        void Move(Transform buildingTransform, Transform targetTransform, bool isAnimated = true);
    }
}