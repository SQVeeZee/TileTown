using _Scripts.Gameplay.Tile;
using _Scripts.Gameplay.Tile.Map.Selection;
using JetBrains.Annotations;
using Zenject;

namespace _Scripts.Gameplay.Building.Impacts.Remove
{
    public interface IRemoveImpactModule: IImpact
    {
        
    }
    
    [UsedImplicitly]
    public class RemoveImpactModule: IRemoveImpactModule
    {
        private readonly ISelectionModule m_selectionModule = null;

        [Inject]
        public RemoveImpactModule(
            ISelectionModule selectionModule)
        {
            m_selectionModule = selectionModule;
        }
        
        void IImpact.DoImpact()
        {
            RemoveBuilding();
        }
        
        public void ResetImpact()
        {
            m_selectionModule.UnSelect();
        }

        private void RemoveBuilding()
        {
            ITileViewModel tileViewModel = m_selectionModule.SelectedTile;
            
            tileViewModel.RemoveBuilding();
            
            ResetImpact();
        }
    }
}