using _Scripts.Gameplay.Tile;
using JetBrains.Annotations;

namespace _Scripts.Gameplay.Building.Impacts.Remove
{
    [UsedImplicitly]
    public class RemoveImpactModule: IRemoveImpactModule
    {
        private ITileViewModel _tileViewModel = null;

        void IImpact.DoImpact(ITileViewModel tileViewModel)
        {
            _tileViewModel = tileViewModel;
            
            RemoveBuilding(tileViewModel);
        }
        
        public void ResetImpact()
        {
            _tileViewModel.UnSelect();
        }

        private void RemoveBuilding(ITileViewModel tileViewModel)
        {
            tileViewModel.RemoveBuilding();
            
            ResetImpact();
        }
    }
}