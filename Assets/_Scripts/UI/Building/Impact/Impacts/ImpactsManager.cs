using System;
using _Scripts.Gameplay.Building.Impacts.Info;
using _Scripts.Gameplay.Building.Impacts.Move;
using _Scripts.Gameplay.Building.Impacts.Remove;
using _Scripts.UI.Building.Impacts;
using _Scripts.UI.Screens;
using Zenject;

namespace _Scripts.Gameplay.Building.Impacts
{
    public class ImpactsManager : IInitializable, IDisposable
    {
        private readonly UIManager m_uiManager = null;
        
        private readonly IUIBuildingImpacts m_uiBuildingImpacts = null;
        private readonly IRemoveImpactModule m_removeImpactModule = null;
        private readonly IMoveImpact m_moveImpact = null;
        private readonly IInfoImpactModule m_showInfoImpactModule = null;

        [Inject]
        public ImpactsManager(
            UIManager uiManager,
            IUIBuildingImpacts uiBuildingImpacts,
            IRemoveImpactModule removeImpactModule,
            IMoveImpact moveImpact,
            IInfoImpactModule showInfoImpactModule
        )
        {
            m_uiManager = uiManager;
            m_uiBuildingImpacts = uiBuildingImpacts;

            m_removeImpactModule = removeImpactModule;
            m_moveImpact = moveImpact;
            m_showInfoImpactModule = showInfoImpactModule;
        }

        void IInitializable.Initialize()
        {
            m_uiBuildingImpacts.ImpactClicked += OnImpactClicked;
        }

        void IDisposable.Dispose()
        {
            m_uiBuildingImpacts.ImpactClicked -= OnImpactClicked;
        }

        private void OnImpactClicked(EImpactType impactType)
        {
            ChooseImpactDependsOnType(impactType);
        }

        private void ChooseImpactDependsOnType(EImpactType impactType)
        {
            switch (impactType)
            {
                case EImpactType.NONE:
                    break;
                case EImpactType.REMOVE:
                    OnRemoveBuilding();
                    break;
                case EImpactType.MOVE:
                    OnMoveBuilding();
                    break;
                case EImpactType.SHOW_INFO:
                    OnShowInfoBuilding();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(impactType), impactType, null);
            }
        }

        private void OnRemoveBuilding()
        {
            m_removeImpactModule.DoImpact();
        }

        private void OnMoveBuilding()
        {
            m_moveImpact.DoImpact();
        }

        private void OnShowInfoBuilding()
        {
            m_showInfoImpactModule.DoImpact();
            
            m_uiManager.ShowScreenByType(EScreenType.BUILDING_INFO);
        }
    }
}