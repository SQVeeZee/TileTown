using _Scripts.Gameplay.Building;
using UniRx;
using UnityEngine;

namespace _Scripts.Gameplay.Tile
{
    public interface ITileViewModel: ISelectable
    {
        IReactiveProperty<bool> IsHighlighted { get; }
        
        IBuilding Building { get; set; }
        Vector3 Position { get; set; }
        Vector3 Size { get; set; }
        Transform BuildingContainer { get; set; }
        
        bool IsEmpty { get; }
            
        void RemoveBuilding();
        void SetTileHighlightState(bool state);
    }
}