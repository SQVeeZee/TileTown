using _Scripts.Gameplay.Building.Impact.Info;
using _Scripts.Gameplay.Building.Impact.Move;
using _Scripts.Gameplay.Building.Impact.Remove;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building
{
    public interface IBuilding
    {
        public void MoveBuilding(Transform buildingTransform, Transform targetTransform);
        public void RemoveBuilding(BuildingView buildingViewModel);
        public void GetBuildingInfo();
    }
    
    public class BuildingViewModel: IBuilding
    {
        private readonly BuildingData m_data = null;
        
        private readonly BuildingMoveModule m_buildingMoveModule = null;
        private readonly BuildingRemoveModule m_buildingRemoveModule = null;
        private readonly BuildingInfoModule m_buildingInfoModule = null;
        
        [Inject]
        public BuildingViewModel(
            BuildingData buildingData,
            BuildingMoveModule buildingMoveModule,
            BuildingRemoveModule buildingRemoveModule,
            BuildingInfoModule buildingInfoModule
        )
        {
            m_data = buildingData;

            m_buildingMoveModule = buildingMoveModule;

            m_buildingRemoveModule = buildingRemoveModule;

            m_buildingInfoModule = buildingInfoModule;
        }
        
        void IBuilding.MoveBuilding(Transform buildingTransform, Transform targetTransform)
        {
            m_buildingMoveModule.ChangePosition(buildingTransform, targetTransform);
        }

        void IBuilding.RemoveBuilding(BuildingView buildingViewModel)
        {
            m_buildingRemoveModule.RemoveBuilding(buildingViewModel);
        }

        void IBuilding.GetBuildingInfo()
        {
            var buildingConfigs = m_data.Data;
            
            m_buildingInfoModule.ShowInfo(buildingConfigs);
        }
        
        [UsedImplicitly]
        public class Factory : PlaceholderFactory<UnityEngine.Object, Transform, BuildingView>
        {
            public override BuildingView Create(Object prefab, Transform parent)
            {
                var instance = base.Create(prefab, parent);

                instance.SetParent(parent);
                
                return instance;
            }
        }
    }
}
