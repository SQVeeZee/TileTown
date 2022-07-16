using System;
using _Scripts.Gameplay.Building.Impact;
using _Scripts.UI.Control;
using Cameras;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile.Map
{
    public class MapController : IInitializable, IDisposable
    {
        public event Action<TileController, TileController> UpdateSelectedTile = null;

        private readonly MapModel m_model = null;
        private readonly MapGenerationSystem m_mapGenerationSystem = null;
        private readonly ControlController m_controlController;
        private readonly CamerasController m_camerasController = null;
        
        private TileController m_selectedTile = null;
        private TileController m_previousSelectedTile = null;
        
        public TileController SelectedTile
        {
            get => m_selectedTile;
            private set
            {
                if (m_selectedTile != value)
                {
                    m_previousSelectedTile = m_selectedTile;
                }

                m_selectedTile = value;

                UpdateSelectedTile?.Invoke(m_previousSelectedTile, m_selectedTile);
            }
        }

        public EMapInteractionState InteractionState { get; private set; } = EMapInteractionState.ALL;

        private TileController[,] m_generatedMap = null;
        private Camera m_uiCamera = null;
        
        [Inject]
        public MapController(
            MapModel model,
            MapGenerationSystem mapGenerationSystem,
            ControlController controlController,
            CamerasController camerasController
        )
        {
            m_model = model;
            m_mapGenerationSystem = mapGenerationSystem;

            m_controlController = controlController;
            m_camerasController = camerasController;
        }

        public void ResetInteractionState()
        {
            InteractionState = EMapInteractionState.ALL;
        }

        public void DisableBuilder()
        {
            InteractionState &= ~EMapInteractionState.BUILDER;
        }

        public void DisableImpactsMenu()
        {
            InteractionState &= ~EMapInteractionState.IMPACTS;
        }

        void IInitializable.Initialize()
        {
            m_mapGenerationSystem.MapGenerated += OnMapGenerate;
            m_controlController.Clicked += OnClicked;
        }

        void IDisposable.Dispose()
        {
            m_mapGenerationSystem.MapGenerated -= OnMapGenerate;
            m_controlController.Clicked -= OnClicked;
        }
        
        private void OnMapGenerate(TileController[,] generatedMap)
        {
            m_generatedMap = generatedMap;
        }

        private void OnClicked(Vector2 worldPosition)
        {
            if (TryGetTileByClick(worldPosition, out TileController tileController))
            {
                SelectedTile = tileController;
            }
        }

        private bool TryGetTileByClick(Vector2 viewPoint, out TileController tile)
        {
            if (m_uiCamera == null)
            {
                m_uiCamera = m_camerasController.GetCamera(ECameraId.UI).Camera;
            }

            var worldPoint = m_uiCamera.ScreenToWorldPoint(viewPoint);

            if (TryGetTileByPosition(worldPoint, out TileController tileController))
            {
                tile = tileController;
                return true;
            }

            tile = null;
            return false;
        }
        
        private bool TryGetTileByPosition(Vector3 clickedPosition, out TileController tile)
        {
            tile = null;
            
            foreach (var tileController in m_generatedMap)
            {
                if (tileController.IsClickedTile(clickedPosition))
                {
                    tile = tileController;
                    return true;
                }
            }

            return false;
        }
    }
}
