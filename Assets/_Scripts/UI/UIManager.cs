using System;
using System.Collections.Generic;
using _Scripts.Gameplay.Building.Impacts.Info;
using _Scripts.UI.Building.Builder;
using _Scripts.UI.Building.Impacts;
using _Scripts.UI.Screen;
using UniRx;
using Zenject;

namespace _Scripts.UI.Screens
{
    public enum EScreenType
    {
        NONE = 0,
        MAIN_MENU = 10,
        GAME = 20,
        
        BUILDER = 30,
        
        BUILDING_INFO = 40,
        
        IMPACTS = 50,
    }

    public class UIManager: IInitializable
    {
        private readonly Dictionary<EScreenType, IScreen> m_screensByType;
        private readonly Stack<IDisposable> m_disposables = new Stack<IDisposable>();
        
        private Stack<IScreen> m_openedScreens;

        [Inject]
        public UIManager(
            UIBuildingsBuilderScreen buildingsBuilderScreen,
            UIBuildingInfoScreen buildingInfoScreen,
            UIBuildingImpactsScreen buildingImpactsScreen)
        {
            m_screensByType = new Dictionary<EScreenType, IScreen>()
            {
                {EScreenType.BUILDER, buildingsBuilderScreen},
                {EScreenType.BUILDING_INFO, buildingInfoScreen},
                {EScreenType.IMPACTS, buildingImpactsScreen}
            };
        }

        void IInitializable.Initialize()
        {
            InitializeScreens();
        }

        private void InitializeScreens()
        {
            foreach (var screenPair in m_screensByType)
            {
                var screen = screenPair.Value;

                m_disposables.Push(screen.IsReadyToHide.Where(isReadyToHide => isReadyToHide)
                    .Subscribe(_ => HideScreen(screen)));
                
                screen.Initialize();
            }
        }
        
        public void ShowScreenByType(EScreenType screenType, Action callback = null)
        {
            IScreen screen = m_screensByType[screenType];
            
            screen.DoShow(callback: callback);
        }

        public void HideScreenByType(EScreenType screenType, Action callback = null)
        {
            m_screensByType[screenType].DoHide(callback: callback);
        }

        public void HideOpenedScreens(bool force, float delay)
        {
            int openedScreensCount = m_openedScreens.Count;
            
            for (int i = 0; i < openedScreensCount; i++)
            {
                IScreen openedScreen = m_openedScreens.Pop();
                openedScreen.DoHide(force, delay);
            }
        }

        private void HideScreen(IScreen screen) => screen.DoHide();
    }
}