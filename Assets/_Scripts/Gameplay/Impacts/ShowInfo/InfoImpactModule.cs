using _Scripts.Gameplay.Building.Configs;
using _Scripts.Gameplay.Tile;
using JetBrains.Annotations;
using UniRx;

namespace _Scripts.Gameplay.Building.Impacts.Info
{
    [UsedImplicitly]
    public class InfoImpactModule: IInfoImpactModule
    {
        public ReactiveProperty<BaseBuildingData> BuildingConfigs { get;  } 
            = new ReactiveProperty<BaseBuildingData>();

        private ITileViewModel _tileViewModel = null;
        
        void IImpact.DoImpact(ITileViewModel tileViewModel)
        {
            _tileViewModel = tileViewModel;

            ShowInfo(tileViewModel);
        }

        void IImpact.ResetImpact()
        {
            _tileViewModel.UnSelect();
        }

        private void ShowInfo(ITileViewModel tileViewModel)
        {
            BuildingConfigs.Value = tileViewModel.Building.BuildingInfo;
        }
    }
}
