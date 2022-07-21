using System;
using _Scripts.Gameplay.Building;
using _Scripts.Gameplay.Tile.Map;
using _Scripts.UI.Building.Builder;
using Zenject;

namespace _Scripts.Gameplay.Tile.Manipulation
{
    public class TileManipulationViewModel: IInitializable, IDisposable
    {
        private readonly IMap m_map = null;
        private readonly UIBuildingsBuilderScreen m_builderScreen = null;
    
        [Inject]
        public TileManipulationViewModel(
            IMap map,
            UIBuildingsBuilderScreen builderScreen
        )
        {
            m_map = map;

            m_builderScreen = builderScreen;
        }

        void IInitializable.Initialize()
        {
            m_map.TileClicked += OnTileClicked;
        }

        void IDisposable.Dispose()
        {
            m_map.TileClicked -= OnTileClicked;
        }

        private void OnTileClicked(TileController tileController)
        {
            if (tileController.GetTileState == ETileState.EMPTY)
            {
                EnableBuilder(tileController);
            }
            else
            {
                EnableImpacts();
            }
        }

        private void EnableBuilder(TileController tileController)
        {
            m_builderScreen.Initialize(tileController.TileTransform);
            
            m_builderScreen.DoShow();
        }
        
        private void EnableImpacts()
        {
            
        }
    }
}
