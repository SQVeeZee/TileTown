using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building
{
    public class BuildingView : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer m_sprite = null;
        [SerializeField] protected Transform m_impactPoint = null;
        
        [SerializeField] private Transform m_transform = null;

        public Transform ImpactPoint => m_impactPoint;

        public IBuilding BuildingViewModel { get; private set; } = null;

        private readonly Stack<IDisposable> m_disposables = new Stack<IDisposable>();
        
        [Inject]
        public void Constructor(
            IBuilding building
            )
        {
            BuildingViewModel = building;
        }

        private void Awake()
        {
            BuildingViewModel.BuildingDestroyed += OnBuildingDestroyed;

            Initialize();
        }

        private void Initialize()
        {
            BuildingViewModel.BuildingTransform = m_transform;
            
            m_disposables.Push(BuildingViewModel.RootTransform
                .ObserveEveryValueChanged(x => x.Value)
                .Subscribe(SetParent));
        }
        
        private void Dispose()
        {
            for (int i = 0; i < m_disposables.Count; i++)
            {
                if (m_disposables.TryPop(out IDisposable disposable))
                {
                    disposable.Dispose();
                }
            }
        }

        private void OnBuildingDestroyed(IBuilding building)
        {
            Dispose();
            
            Destroy(gameObject);
        }

        private void SetParent(Transform parent)
        {
            m_transform.SetParent(parent, false);
        }
    }
}