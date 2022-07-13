using Gameplay.Building.Impact.Info;
using _Scripts.UI.Building.Impact.Info;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building.Impact
{
    public class BuildingInfoMonoInstaller : MonoInstaller
    {
        [SerializeField] private UIBuildingInfoPanel m_buildingInfoPanel = null;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UIBuildingInfoPanel>().FromComponentInNewPrefab(m_buildingInfoPanel)
                .AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<BuildingInfoViewModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BuildingInfoModel>().AsSingle().NonLazy();
        }
    }
}
