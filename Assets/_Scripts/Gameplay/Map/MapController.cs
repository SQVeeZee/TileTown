using System;
using Cameras;
using Gameplay.Building.Builder;
using Gameplay.Tile;
using Gameplay.UI.Control;
using UI.Building.Impact.Impacts;
using UnityEngine;
using Zenject;

namespace Gameplay.Map
{
    public class MapController : IInitializable, IDisposable
    {
        public event Action<TileController> EmptyTileClicked = null;
        public event Action<TileController> FilledTileClicked = null;
        
        private readonly MapGenerationSystem m_mapGenerationSystem = null;
        private readonly ControlController m_controlController;
        private readonly CamerasController m_camerasController = null;

        private readonly BuildingImpactsModel m_buildingImpactsModel;
        private readonly BuildingBuilderModel m_buildingBuilderModel;
        
        private TileController[,] m_generatedMap = null;
        
        private Camera m_uiCamera = null;
        
        [Inject]
        public MapController(
            MapGenerationSystem mapGenerationSystem,
            ControlController controlController,
            CamerasController camerasController,
            BuildingImpactsModel buildingImpactsModel,
            BuildingBuilderModel buildingBuilderModel
        )
        {
            m_mapGenerationSystem = mapGenerationSystem;

            m_controlController = controlController;
            m_camerasController = camerasController;
            
            m_buildingImpactsModel = buildingImpactsModel;
            m_buildingBuilderModel = buildingBuilderModel;
        }

        void IInitializable.Initialize()
        {
            m_buildingImpactsModel.Add(this);
            m_buildingBuilderModel.Add(this);

            m_mapGenerationSystem.MapGenerated += OnMapGenerate;
            m_controlController.Clicked += OnClicked;
        }

        void IDisposable.Dispose()
        {
            m_buildingImpactsModel.Remove(this);
            m_buildingBuilderModel.Remove(this);
            
            m_mapGenerationSystem.MapGenerated -= OnMapGenerate;
            m_controlController.Clicked -= OnClicked;
        }

        private void OnClicked(Vector2 worldPosition)
        {
            DefineTileState(worldPosition);
        }

        private void OnMapGenerate(TileController[,] generatedMap)
        {
            m_generatedMap = generatedMap;
        }

        private void DefineTileState(Vector2 viewPoint)
        {
            if (m_uiCamera == null)
            {
                m_uiCamera = m_camerasController.GetCamera(ECameraId.UI).Camera;
            }
            
            var worldPoint = m_uiCamera.ScreenToWorldPoint(viewPoint);
            
            if (TryGetTileByPosition(worldPoint, out TileController tileController))
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
        }

        private void ClickedFilledTile(TileController tile) => FilledTileClicked?.Invoke(tile);
        private void ClickedEmptyTile(TileController tile) => EmptyTileClicked?.Invoke(tile);

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
