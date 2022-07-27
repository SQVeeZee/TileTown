namespace _Scripts.Gameplay.Tile.Map.Click
{
    public abstract class BaseMapClickListener
    {
        protected abstract MapClickMode ClickMode { get; }
        
        private readonly IClickModeListener _clickModeListener = null;
        private readonly IMapClickHandler _mapClickHandler = null;

        protected abstract void OnClickTile(ITileViewModel tile);
        
        protected BaseMapClickListener(
            IMapClickHandler mapClickHandler,
            IClickModeListener clickModeListener
            )
        {
            _mapClickHandler = mapClickHandler;
            _clickModeListener = clickModeListener;
        }

        protected void Initialize()
        {
            _clickModeListener.ClickModeChanged += OnClickModeChanged;
            _clickModeListener.ClickModeRemoved += OnClickModeRemoved;
            _clickModeListener.ClickModeAdded += OnClickModeAdded;
            
            if (_clickModeListener.HasClickMode(ClickMode))
            {
                ListenMapClicks();
            }
        }

        protected void Dispose()
        {
            _clickModeListener.ClickModeChanged -= OnClickModeChanged;
            _clickModeListener.ClickModeRemoved -= OnClickModeRemoved;
            _clickModeListener.ClickModeAdded -= OnClickModeAdded;
        }

        protected void ResetClickListen()
        {
            _clickModeListener.RemoveClickMode(ClickMode);
        }

        protected void AddClickListen()
        {
            _clickModeListener.AddClickMode(ClickMode);
        }

        private void OnClickModeChanged(MapClickMode clickMode)
        {
            if (clickMode.HasFlag(ClickMode))
            {
                ListenMapClicks();
            }
            else
            {
                StopListenMapClicks();
            }
        }

        private void OnClickModeRemoved(MapClickMode clickMode)
        {
            if (clickMode == ClickMode)
            {
                StopListenMapClicks();
            }
        }
        
        private void OnClickModeAdded(MapClickMode clickMode)
        {
            if (clickMode == ClickMode)
            {
                ListenMapClicks();
            }
        }

        private void ListenMapClicks()
        {
            _mapClickHandler.TileClicked += OnClickTile;
        }

        private void StopListenMapClicks()
        {
            _mapClickHandler.TileClicked -= OnClickTile;
        }
    }
}
