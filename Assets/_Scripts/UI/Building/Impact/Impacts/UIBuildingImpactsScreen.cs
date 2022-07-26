using System;
using _Scripts.Gameplay.Building.Impacts;
using _Scripts.UI.Screen;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Building.Impacts
{
    public class UIBuildingImpactsScreen : BaseScreen
    {
        [SerializeField] private Transform m_impactParent = null;

        private IUIBuildingImpacts m_impactsViewModel = null;
        private IDisposable m_disposableConfigs = null;
        
        [Inject]
        public void Constructor(
            IUIBuildingImpacts impactsViewModel
        )
        {
            m_impactsViewModel = impactsViewModel;
        }

        public override void Initialize()
        {
            m_impactsViewModel.ImpactClicked += OnImpactClicked;
            
            m_disposableConfigs = m_impactsViewModel.BuildingImpactsConfigs.Where(x => x != null)
                .Subscribe(_=> OnImpactsConfigsUpdate());
        }

        public override void Dispose()
        {
            m_impactsViewModel.ImpactClicked -= OnImpactClicked;
        }

        protected override void OnBeforeScreenHide()
        {
            base.OnBeforeScreenHide();
            
            m_disposableConfigs?.Dispose();
        }

        private void OnImpactsConfigsUpdate()
        {
            m_impactsViewModel.CreateImpacts(m_impactParent);
        }

        private void OnImpactClicked(EImpactType impactType)
        {
            IsReadyToHide.Value = true;
        }
    }
}