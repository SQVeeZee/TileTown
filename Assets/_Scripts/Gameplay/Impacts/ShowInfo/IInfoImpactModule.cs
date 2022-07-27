using _Scripts.Gameplay.Building.Configs;
using UniRx;

namespace _Scripts.Gameplay.Building.Impacts.Info
{
    public interface IInfoImpactModule: IImpact
    {
        ReactiveProperty<BaseBuildingData> BuildingConfigs { get; }
    }
}