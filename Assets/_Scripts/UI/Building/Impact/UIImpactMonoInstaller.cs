using UI.Building.Impact;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building.Impact
{
    public class UIImpactMonoInstaller : MonoInstaller
    {
        [SerializeField] private UIBuildingImpactView m_view;
        [SerializeField] private BuildingImpactViewModel m_impactViewModel = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UIBuildingImpactModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIBuildingImpactView>().FromInstance(m_view).AsSingle();

            // switch (m_impactViewModel.ImpactType)
            // {
            //     case EBuildingImpactType.NONE:
            //         break;
            //     case EBuildingImpactType.REMOVE:
            //         break;
            //     case EBuildingImpactType.MOVE:
            //         break;
            //     case EBuildingImpactType.SHOW_INFO:
            //         Container.BindInterfacesAndSelfTo<BuildingInfoViewModel>()
            //             .FromNewComponentOnNewPrefab(m_impactViewModel).AsSingle();
            //         break;
            //     default:
            //         throw new ArgumentOutOfRangeException();
        }
    }
}
