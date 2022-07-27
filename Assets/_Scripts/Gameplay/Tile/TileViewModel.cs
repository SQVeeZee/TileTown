using _Scripts.Gameplay.Building;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;

namespace _Scripts.Gameplay.Tile
{
    [UsedImplicitly]
    public class TileViewModel: ITileViewModel
    {
        public IReactiveProperty<bool> IsSelected { get; } = new ReactiveProperty<bool>();
        public IReactiveProperty<bool> IsHighlighted { get; } = new ReactiveProperty<bool>();

        public Vector3 Size { get; set; }
        public Vector3 Position { get; set; }

        public Transform BuildingContainer { get; set; }
        
        public IBuilding Building { get; set; } = null;

        public bool IsEmpty => Building == null;

        void ITileViewModel.RemoveBuilding()
        {
            if (Building == null) return;
            
            Building.RemoveBuilding();
            
            Building = null;
        }

        void ITileViewModel.SetTileHighlightState(bool state)
        {
            IsHighlighted.Value = state;
        }

        void ISelectable.Select()
        {
            IsSelected.Value = true;
        }

        void ISelectable.UnSelect()
        {
            IsSelected.Value = false;
        }
    }
}