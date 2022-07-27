using System;
using _Scripts.Gameplay.Building.Configs;
using _Scripts.Gameplay.Building.Impact.Configs;
using _Scripts.Gameplay.Building.Impacts.Move;
using _Scripts.UI.Building.Impacts.Configs;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace _Scripts.Gameplay.Building
{
    public class BuildingViewModel: IBuilding
    {
        public event Action<IBuilding> BuildingDestroyed;
        
        public IReactiveProperty<Transform> RootTransform { get; } = new ReactiveProperty<Transform>();
        public Transform BuildingTransform { get; set; }

        public BaseBuildingData BuildingInfo { get; } = null;
        public BuildingImpactsConfigs ImpactsConfigs { get; private set; }

        private readonly IBuildingMoveModule _buildingMoveModule = null;
        
        [Inject]
        public BuildingViewModel(
            BaseBuildingConfigs baseBuildingConfigs,
            BuildingImpactsConfigs impactsConfigs,
            IBuildingMoveModule buildingMoveModule
        )
        {
            BuildingInfo = baseBuildingConfigs.BuildingData;
            ImpactsConfigs = impactsConfigs;
            
            _buildingMoveModule = buildingMoveModule;
        }
        
        void IBuilding.SetRootTransform(Transform parent)
        {
            RootTransform.Value = parent;
        }
        
        void IBuilding.MoveBuilding(Transform targetTransform, bool isAnimated)
        {
            _buildingMoveModule.Move(BuildingTransform, targetTransform, isAnimated);
        }

        void IBuilding.RemoveBuilding()
        {
            BuildingDestroyed?.Invoke(this);
        }
        
        [UsedImplicitly]
        public class Factory : PlaceholderFactory<UnityEngine.Object, Transform, BuildingView>
        {
            public override BuildingView Create(Object prefab, Transform parent)
            {
                var instance = base.Create(prefab, parent);

                var building = instance.BuildingViewModel;
                building.RootTransform.Value = parent;
                
                return instance;
            }
        }
    }
}
