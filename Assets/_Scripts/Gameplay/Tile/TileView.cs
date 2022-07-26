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
        [SerializeField] private Transform m_tileTransform = null;
        [SerializeField] private Transform m_hudPoint = null;

        [Header("View")] 
        [SerializeField] private SpriteRenderer m_sprite = null;

        public ITileViewModel TileViewModel { get; private set; }
        
        public Transform HudPoint => m_hudPoint;
        public Transform TileTransform => m_tileTransform;
        
        private TileData m_tileData = null;
        private Color m_defaultColor = Color.white;

        private List<IDisposable> m_disposables = new List<IDisposable>();
        
        [Inject]
        public void Constructor(
            ITileViewModel viewModel,
            TileViewConfigs viewConfigs
            )
        {
            TileViewModel = viewModel;
            
            m_tileData = viewConfigs.TileData;
        }
        
        public void OnSpawned(Vector3 position, Transform parent)
        {
            TileViewModel.BuildingContainer = m_tileTransform;
            SetTileSize();
            
            m_defaultColor = m_sprite.color;
            
            m_tileTransform.SetParent(parent);
            m_tileTransform.position = position;

            TileViewModel.Position = position;

            SubscribeOnDataUpdate();
        }

        private void SetTileSize()
        {
            var tileSize = m_tileTransform.lossyScale / 2;
            TileViewModel.Size = tileSize;
        }

        private void SubscribeOnDataUpdate()
        {
            m_disposables.Add(TileViewModel.IsHighlighted
                .ObserveEveryValueChanged(x => x.Value)
                .Subscribe(OnHighlightStateChanged));
            
            m_disposables.Add(TileViewModel.IsSelected
                .ObserveEveryValueChanged(x => x.Value)
                .Subscribe(OnSelectedStateChanged));
        }
        
        public void OnDespawned()
        {
            foreach (var disposable in m_disposables)
            {
                disposable.Dispose();
            }
            m_disposables.Clear();
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
            m_sprite.color = state ? m_tileData.SelectedColor : m_defaultColor;
        }

        private void ToggleHighlightingColor(bool state)
        {
            m_sprite.color = state ? m_tileData.InteractiveColor : m_defaultColor;
        }

        [UsedImplicitly]
        public class Pool : MonoPoolableMemoryPool<Vector3, Transform, TileView>
        {
            
        }
    }
}