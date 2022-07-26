using System;
using _Scripts.Gameplay.Tile;
using _Scripts.Gameplay.Tile.Map.Click;
using _Scripts.Gameplay.Tile.Map.Highlighting;
using Zenject;

namespace _Scripts.Gameplay.Building.Impacts.Move
{
    public interface IMoveImpact : IImpact
    {
    }
    
    public class MoveImpactViewModel: BaseMapClickListener, IMoveImpact, IInitializable, IDisposable
    {
        protected override MapClickMode ClickMode => MapClickMode.MOVE;
        
        private readonly IMoveImpactModule m_impactModule = null;
        private readonly IHighlightingModule m_highlightingModule = null;

        [Inject]
        public MoveImpactViewModel(
            IMoveImpactModule moveImpactModule,
            IHighlightingModule highlightingModule,

            IMapClickHandler mapClickHandler,
            IClickModeListener clickModeListener
        ):base (mapClickHandler, clickModeListener)
        {
            m_impactModule = moveImpactModule;
            m_highlightingModule = highlightingModule;
        }

        void IInitializable.Initialize() => base.Initialize();
        void IDisposable.Dispose() => base.Dispose();

        void IImpact.DoImpact()
        {
            AddClickListen();
            
            m_highlightingModule.HighlightFreeTiles();
        }

        public void ResetImpact()
        {
            ResetClickListen();

            m_highlightingModule.ResetHighlighting();
            m_impactModule.ResetTileSelection();
        }
        
        protected override void OnClickTile(ITileViewModel tile)
        {
            OnClickTargetTile(tile);
        }
        
        private void OnClickTargetTile(ITileViewModel tileViewModel)
        {
            m_impactModule.DoMoveImpact(tileViewModel, ResetImpact);
        }
    }
}
