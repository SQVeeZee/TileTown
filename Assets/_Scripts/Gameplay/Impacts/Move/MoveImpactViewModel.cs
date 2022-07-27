using System;
using _Scripts.Gameplay.Tile;
using _Scripts.Gameplay.Tile.Map.Click;
using _Scripts.Gameplay.Tile.Map.Highlighting;
using Zenject;

namespace _Scripts.Gameplay.Building.Impacts.Move
{
    public class MoveImpactViewModel : BaseMapClickListener, IMoveImpact, IInitializable, IDisposable
    {
        protected override MapClickMode ClickMode => MapClickMode.Move;

        private readonly IMoveImpactModule _impactModule = null;
        private readonly IHighlightingModule _highlightingModule = null;

        private ITileViewModel _tileViewModel = null;

        [Inject]
        public MoveImpactViewModel(
            IMoveImpactModule moveImpactModule,
            IHighlightingModule highlightingModule,

            IMapClickHandler mapClickHandler,
            IClickModeListener clickModeListener
        ) : base(mapClickHandler, clickModeListener)
        {
            _impactModule = moveImpactModule;
            _highlightingModule = highlightingModule;
        }

        void IInitializable.Initialize()
        {
            base.Initialize();

            _impactModule.MoveImpactCompleted += OnMoveImpactCompleted;
        }

        void IDisposable.Dispose()
        {
            base.Dispose();
            
            _impactModule.MoveImpactCompleted -= OnMoveImpactCompleted;
        }

        public void DoImpact(ITileViewModel tileViewModel)
        {
            _tileViewModel = tileViewModel;
            
            AddClickListen();
            
            _highlightingModule.HighlightFreeTiles();
        }

        public void ResetImpact()
        {
            ResetClickListen();

            _highlightingModule.ResetHighlighting();
        }
        
        protected override void OnClickTile(ITileViewModel tile)
        {
            OnClickTargetTile(tile);
        }
        
        private void OnClickTargetTile(ITileViewModel tileViewModel)
        {
            _impactModule.DoMoveImpact(_tileViewModel, tileViewModel);
        }
        
        private void OnMoveImpactCompleted()
        {
            ResetImpact();
        }
    }
}
