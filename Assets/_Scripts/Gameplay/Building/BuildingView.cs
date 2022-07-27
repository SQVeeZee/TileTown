using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building
{
    public class BuildingView : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer _sprite = null;
        [SerializeField] protected Transform _impactPoint = null;
        
        [SerializeField] private Transform _transform = null;

        public Transform ImpactPoint => _impactPoint;

        public IBuilding BuildingViewModel { get; private set; } = null;

        private readonly Stack<IDisposable> _disposables = new Stack<IDisposable>();
        
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
            BuildingViewModel.BuildingTransform = _transform;
            
            _disposables.Push(BuildingViewModel.RootTransform
                .ObserveEveryValueChanged(x => x.Value)
                .Subscribe(SetParent));
        }
        
        private void Dispose()
        {
            for (int i = 0; i < _disposables.Count; i++)
            {
                if (_disposables.TryPop(out IDisposable disposable))
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
            _transform.SetParent(parent, false);
        }
    }
}