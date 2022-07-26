using System;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile.Map.Click
{
    public abstract class BaseMapClickListener
    {
        protected abstract MapClickMode ClickMode { get; }
        
        private readonly IClickModeListener m_clickModeListener = null;
        private readonly IMapClickHandler m_mapClickHandler = null;

        protected abstract void OnClickTile(ITileViewModel tile);
        
        protected BaseMapClickListener(
            IMapClickHandler mapClickHandler,
            IClickModeListener clickModeListener
            )
        {
            m_mapClickHandler = mapClickHandler;
            m_clickModeListener = clickModeListener;
        }

        protected void Initialize()
        {
            m_clickModeListener.ClickModeChanged += OnClickModeChanged;
            m_clickModeListener.ClickModeRemoved += OnClickModeRemoved;
            m_clickModeListener.ClickModeAdded += OnClickModeAdded;
            
            if (m_clickModeListener.HasClickMode(ClickMode))
            {
                ListenMapClicks();
            }
        }

        protected void Dispose()
        {
            m_clickModeListener.ClickModeChanged -= OnClickModeChanged;
            m_clickModeListener.ClickModeRemoved -= OnClickModeRemoved;
            m_clickModeListener.ClickModeAdded -= OnClickModeAdded;
        }

        protected void ResetClickListen()
        {
            m_clickModeListener.RemoveClickMode(ClickMode);
        }

        protected void AddClickListen()
        {
            m_clickModeListener.AddClickMode(ClickMode);
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
            m_mapClickHandler.TileClicked += OnClickTile;
        }

        private void StopListenMapClicks()
        {
            m_mapClickHandler.TileClicked -= OnClickTile;
        }
    }
}
