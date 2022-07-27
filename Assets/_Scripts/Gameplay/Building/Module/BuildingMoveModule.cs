using _Scripts.Gameplay.Building.Impacts.Move;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;

namespace _Scripts.Gameplay.Building.Module
{
    [UsedImplicitly]
    public class BuildingMoveModule : IBuildingMoveModule
    {
        private Tweener _moveTween = null;
        
        void IBuildingMoveModule.Move(Transform buildingTransform, Transform targetTransform, bool isAnimated)
        {
            if (isAnimated)
            {
                DoMove(buildingTransform, targetTransform);
                buildingTransform.SetParent(targetTransform, true);
            }
            else
            {
                buildingTransform.SetParent(targetTransform, false);
            }
        }
        
        private void DoMove(Transform buildingTransform, Transform targetTransform)
        {
            ResetMove();
            
            Vector3 targetPosition = targetTransform.position;
            
            _moveTween = buildingTransform.DOMove(targetPosition, 0.5f);
        }
        
        private void ResetMove()
        {
            _moveTween?.Kill();
            _moveTween = null;
        }
    }
}