using _Scripts.Gameplay.Building.Configs;
using _Scripts.Gameplay.Tile;
using _Scripts.Gameplay.Tile.Map.Selection;
using _Scripts.UI.Screens;
using JetBrains.Annotations;
using UniRx;
using Zenject;

namespace _Scripts.Gameplay.Building.Impacts.Info
{
    public interface IInfoImpactModule: IImpact
    {
        ReactiveProperty<BaseBuildingData> BuildingConfigs { get; }
    }
    
    [UsedImplicitly]
    public class InfoImpactModule: IInfoImpactModule
    {
        public ReactiveProperty<BaseBuildingData> BuildingConfigs { get;  } 
            = new ReactiveProperty<BaseBuildingData>();

        private readonly ISelectionModule m_selectionModule = null;

        [Inject]
        public InfoImpactModule(
            ISelectionModule selectionModule
            )
        {
            m_selectionModule = selectionModule;
        }
        
        void IImpact.DoImpact()
        {
            ShowInfo();
        }

        void IImpact.ResetImpact()
        {
            m_selectionModule.UnSelect();
        }

        private void ShowInfo()
        {
            ITileViewModel tileViewModel = m_selectionModule.SelectedTile;

            BuildingConfigs.Value = tileViewModel.Building.BuildingInfo;
        }
    }
}
