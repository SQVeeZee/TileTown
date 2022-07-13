using System;
using System.Collections.Generic;
using _Scripts.Gameplay.Building;
using _Scripts.Gameplay.Building.Impact.Impacts;
using _Scripts.UI.Control;
using Cameras;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile.Map
{
    [Flags]
    public enum EMapInteractionState: byte
    {
        NONE = 0,
        
        INTERACTION = 1,
        POSITION_REPLACE = 2
    }
    
    public class MapController : IInitializable, IDisposable
    {
        public event Action<TileController> EmptyTileClicked = null;
        
        private readonly MapGenerationSystem m_mapGenerationSystem = null;
        private readonly ControlController m_controlController;
        private readonly CamerasController m_camerasController = null;
        private readonly ImpactsController m_impacts = null;
        
        private TileController[,] m_generatedMap = null;
        private Camera m_uiCamera = null;

        private EMapInteractionState m_interactionState = EMapInteractionState.INTERACTION;
        private BuildingViewModel m_selectedBuilding = null;
        
        [Inject]
        public MapController(
            MapGenerationSystem mapGenerationSystem,
            ControlController controlController,
            CamerasController camerasController,
            
            ImpactsController impactsController
        )
        {
            m_mapGenerationSystem = mapGenerationSystem;

            m_controlController = controlController;
            m_camerasController = camerasController;

            m_impacts = impactsController;
        }

        void IInitializable.Initialize()
        {
            m_mapGenerationSystem.MapGenerated += OnMapGenerate;
            m_controlController.Clicked += OnClicked;

            m_impacts.MoveImpactClicked += OnMoveImpactClicked;
        }

        void IDisposable.Dispose()
        {
            m_mapGenerationSystem.MapGenerated -= OnMapGenerate;
            m_controlController.Clicked -= OnClicked;
            
            m_impacts.MoveImpactClicked -= OnMoveImpactClicked;
        }
        
        private void OnMapGenerate(TileController[,] generatedMap)
        {
            m_generatedMap = generatedMap;
        }

        private void OnMoveImpactClicked()
        {
            ChangeInteractionState(EMapInteractionState.POSITION_REPLACE);
            
            HighlightFreeTiles();
        }

        private List<TileController> m_highlightedTiles;
        
        private void HighlightFreeTiles()
        {
            m_highlightedTiles = new List<TileController>();
            
            foreach (var tileController in m_generatedMap)
            {
                m_highlightedTiles.Add(tileController);
                
                tileController.TryToHighlight();
            }
        }

        private void StopHighlight()
        {
            if (m_highlightedTiles.Count == 0) return;
            
            foreach (var highlightedTile in m_highlightedTiles)
            {
                highlightedTile.ChangeToDefaultColor();
            }

            m_highlightedTiles.Clear();
        }

        private void ChangeInteractionState(EMapInteractionState state)
        {
            m_interactionState = state;
        }

        private void OnClicked(Vector2 worldPosition)
        {
            if (TryGetTileByClick(worldPosition, out TileController tileController))
            {
                switch (m_interactionState)
                {
                    case EMapInteractionState.INTERACTION:
                        NotifyBaseOnTileState(tileController);
                        break;
                    case EMapInteractionState.POSITION_REPLACE:
                        ReplaceSelectedBuildingPosition(tileController);
                        break;
                }
            }
        }

        private void ReplaceSelectedBuildingPosition(TileController tileController)
        {
            if (tileController.TileState == ETileState.FILLED) return;
            
            StopHighlight();
            
            Transform targetTransform = tileController.TileTransform;
            m_selectedBuilding.ChangePosition(targetTransform);
            m_selectedBuilding.SetParent(targetTransform, true);

            tileController.SetTileBuilding(m_selectedBuilding);
            
            m_selectedBuilding = null;
            ChangeInteractionState(EMapInteractionState.INTERACTION);
        }

        private void NotifyBaseOnTileState(TileController tileController)
        {
            ETileState tileState = tileController.TileState;

            switch (tileState)
            {
                case ETileState.EMPTY:
                    ClickedEmptyTile(tileController);
                    break;
                case ETileState.FILLED:
                    ClickedFilledTile(tileController);
                    break;
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

        private void ClickedFilledTile(TileController tileController)
        {
            m_selectedBuilding = tileController.BuildingViewModel;
            m_impacts.EnableImpactsView(m_selectedBuilding);
        }

        private void ClickedEmptyTile(TileController tile) => EmptyTileClicked?.Invoke(tile);
    }
}
