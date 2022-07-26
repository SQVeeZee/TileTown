using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;

namespace _Scripts.Gameplay.Building.Impacts.Move
{
    [UsedImplicitly]
    public class BuildingMoveModule
    {
        private Tweener m_moveTween = null;
        
        private void DoMove(Transform buildingTransform, Transform targetTransform)
        {
            ResetMove();
            
            Vector3 targetPosition = targetTransform.position;
            
            m_moveTween = buildingTransform.DOMove(targetPosition, 0.5f);
        }
        
        private void ResetMove()
        {
            m_moveTween?.Kill();
            m_moveTween = null;
        }
        
        public void ChangePosition(Transform buildingTransform, Transform targetTransform, bool isAnimated = true)
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
    }
}