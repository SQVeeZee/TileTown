using System;
using System.Collections.Generic;
using _Scripts.Gameplay.Tile.Configs;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile
{
    public class TileView : MonoBehaviour, IPoolable<Vector3, Transform>
    {
        [Header("BuildingContainer")]
        [SerializeField] private Transform _tileTransform = null;
        [SerializeField] private Transform _hudPoint = null;

        [Header("View")] 
        [SerializeField] private SpriteRenderer _sprite = null;

        public ITileViewModel TileViewModel { get; private set; }
        
        public Transform HudPoint => _hudPoint;
        public Transform TileTransform => _tileTransform;

        private readonly List<IDisposable> _disposables = new List<IDisposable>();
        
        private TileData _tileData = null;
        private Color _defaultColor = Color.white;

        
        [Inject]
        public void Constructor(
            ITileViewModel viewModel,
            TileViewConfigs viewConfigs
            )
        {
            TileViewModel = viewModel;
            
            _tileData = viewConfigs.TileData;
        }
        
        public void OnSpawned(Vector3 position, Transform parent)
        {
            TileViewModel.BuildingContainer = _tileTransform;
            SetTileSize();
            
            _defaultColor = _sprite.color;
            
            _tileTransform.SetParent(parent);
            _tileTransform.position = position;

            TileViewModel.Position = position;

            SubscribeOnDataUpdate();
        }

        private void SetTileSize()
        {
            var tileSize = _tileTransform.lossyScale / 2;
            TileViewModel.Size = tileSize;
        }

        private void SubscribeOnDataUpdate()
        {
            _disposables.Add(TileViewModel.IsHighlighted
                .ObserveEveryValueChanged(x => x.Value)
                .Subscribe(OnHighlightStateChanged));
            
            _disposables.Add(TileViewModel.IsSelected
                .ObserveEveryValueChanged(x => x.Value)
                .Subscribe(OnSelectedStateChanged));
        }
        
        public void OnDespawned()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
            _disposables.Clear();
        }

        private void OnHighlightStateChanged(bool highlightState)
        {
            ToggleHighlightingColor(highlightState);
        }

        private void OnSelectedStateChanged(bool isSelected)
        {
            ToggleSelectColor(isSelected);
        }
        
        private void ToggleSelectColor(bool state)
        {
            _sprite.color = state ? _tileData.SelectedColor : _defaultColor;
        }

        private void ToggleHighlightingColor(bool state)
        {
            _sprite.color = state ? _tileData.InteractiveColor : _defaultColor;
        }

        [UsedImplicitly]
        public class Pool : MonoPoolableMemoryPool<Vector3, Transform, TileView>
        {
            
        }
    }
}