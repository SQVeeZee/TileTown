using System;
using _Scripts.Gameplay.Building.Impact.Configs;
using _Scripts.UI.Building.Impacts;
using _Scripts.UI.Screen;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Building.Impact.Impacts
{
    public class UIBuildingImpactsScreen : BaseScreen
    {
        [SerializeField] private Transform _impactParent = null;

        private IUIBuildingImpacts _impactsViewModel = null;
        private IDisposable _disposableConfigs = null;
        
        [Inject]
        public void Constructor(
            IUIBuildingImpacts impactsViewModel
        )
        {
            _impactsViewModel = impactsViewModel;
        }

        public override void Initialize()
        {
            _impactsViewModel.ImpactClicked += OnImpactClicked;
            
            _disposableConfigs = _impactsViewModel.BuildingImpactsConfigs
                .ObserveEveryValueChanged(x => x.Value)
                .Subscribe(OnImpactsConfigsUpdate);
        }

        public override void Dispose()
        {
            _impactsViewModel.ImpactClicked -= OnImpactClicked;
        }

        private void OnImpactsConfigsUpdate(BuildingImpactsConfigs buildingImpactsConfigs)
        {
            _impactsViewModel.ResetImpacts();
            
            if (buildingImpactsConfigs == null) return;
            
            _impactsViewModel.CreateImpacts(_impactParent);
        }

        private void OnImpactClicked(EImpactType impactType)
        {
            IsReadyToHide.Value = true;
        }
    }
}