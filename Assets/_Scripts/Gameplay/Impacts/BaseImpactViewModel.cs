using System;
using _Scripts.Gameplay.Building.Impact.Impacts;
using Zenject;

namespace _Scripts.Gameplay.Building.Impact
{
    public abstract class BaseImpactViewModel : IInitializable, IDisposable
    {
        protected abstract EImpactType m_impactType { get; }

        private readonly ImpactsController m_impactsController = null;

        protected abstract void Initialize();
        protected abstract void Dispose();
        
        protected abstract void DoImpact();

        [Inject]
        protected BaseImpactViewModel(
            ImpactsController impactsController
        )
        {
            m_impactsController = impactsController;
        }
        
        void IInitializable.Initialize()
        {
            m_impactsController.ClickImpact += OnImpactClicked;

            Initialize();
        }

        void IDisposable.Dispose()
        {
            m_impactsController.ClickImpact -= OnImpactClicked;
            
            Dispose();
        }

        private void OnImpactClicked(EImpactType impactType)
        {
            if (m_impactType != impactType) return;

            DoImpact();
        }
    }
}