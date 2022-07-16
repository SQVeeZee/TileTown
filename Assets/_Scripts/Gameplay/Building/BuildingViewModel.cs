using System;
using _Scripts.Gameplay.Building.Configs;
using DG.Tweening;
using JetBrains.Annotations;
using _Scripts.UI.Building.Impact.Impacts.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building
{
    public class BuildingViewModel: MonoBehaviour
    {
        public event Action TileMove = null;
        public event Action TileRemove = null;
        
        [SerializeField] private Transform m_transform;
        
        private BuildingModel m_model = null;
        private BuildingView m_view = null;
        
        public BaseBuildingConfigs Configs => m_model.Configs;
        public BuildingImpactsConfigs ImpactConfigs => m_model.ImpactsConfigs;
        public Transform ImpactPoint => m_view.ImpactPoint;
        
        private Tweener m_moveTween = null;
        
        [Inject]
        public void Constructor(
            BuildingModel buildingModel,
            BuildingView buildingView
        )
        {
            m_model = buildingModel;
            m_view = buildingView;
        }

        public void Remove()
        {
            TileRemove?.Invoke();
            
            Destroy(gameObject);
        }

        public void ChangePosition(Transform targetTransform, bool isAnimated = true)
        {
            TileMove?.Invoke();
            
            if (isAnimated)
            {
                DoMove(targetTransform);
            }
            else
            {
                SetPosition(targetTransform);
            }
            
            m_transform.SetParent(targetTransform, true);
        }

        private void DoMove(Transform targetTransform)
        {
            ResetMove();
            
            Vector3 targetPosition = targetTransform.position;
            
            m_moveTween = m_transform.DOMove(targetPosition, 0.5f);
        }

        private void ResetMove()
        {
            m_moveTween?.Kill();
            m_moveTween = null;
        }

        private void SetPosition(Transform targetTransform)
        {
            m_transform.position = targetTransform.position;
        }

        public void SetParent(Transform parent, bool positionStays = false)
        {
            m_transform.SetParent(parent, positionStays);
        }
        
        [UsedImplicitly]
        public class Factory : PlaceholderFactory<UnityEngine.Object, Transform, BuildingViewModel>
        {
            public override BuildingViewModel Create(UnityEngine.Object prefab, Transform parent)
            {
                var instance = base.Create(prefab, parent);

                instance.SetParent(parent);
                
                return instance;
            }
        }
    }
}
