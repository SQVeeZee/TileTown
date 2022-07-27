using System;
using System.Collections.Generic;
using _Scripts.Gameplay.Building.Impacts.Info;
using _Scripts.UI.Building.Builder;
using _Scripts.UI.Building.Impact.Impacts;
using _Scripts.UI.Building.Impacts;
using _Scripts.UI.Building.Info;
using _Scripts.UI.Screen;
using UniRx;
using Zenject;

namespace _Scripts.UI.Screens
{
    public enum EScreenType
    {
        None = 0,
        MainMenu = 10,
        Game = 20,
        
        Builder = 30,
        
        BuildingInfo = 40,
        
        Impacts = 50,
    }

    public class UIManager: IInitializable
    {
        private readonly Dictionary<EScreenType, IScreen> _screensByType;
        private readonly Stack<IDisposable> _disposables = new Stack<IDisposable>();
        
        private Stack<IScreen> _openedScreens;

        [Inject]
        public UIManager(
            UIBuildingsBuilderScreen buildingsBuilderScreen,
            UIBuildingInfoScreen buildingInfoScreen,
            UIBuildingImpactsScreen buildingImpactsScreen)
        {
            _screensByType = new Dictionary<EScreenType, IScreen>()
            {
                {EScreenType.Builder, buildingsBuilderScreen},
                {EScreenType.BuildingInfo, buildingInfoScreen},
                {EScreenType.Impacts, buildingImpactsScreen}
            };
        }

        void IInitializable.Initialize()
        {
            InitializeScreens();
        }

        private void InitializeScreens()
        {
            foreach (var screenPair in _screensByType)
            {
                var screen = screenPair.Value;

                _disposables.Push(screen.IsReadyToHide.Where(isReadyToHide => isReadyToHide)
                    .Subscribe(_ => HideScreen(screen)));
                
                screen.Initialize();
            }
        }
        
        public void ShowScreenByType(EScreenType screenType, Action callback = null)
        {
            IScreen screen = _screensByType[screenType];
            
            screen.DoShow(callback: callback);
        }

        public void HideScreenByType(EScreenType screenType, Action callback = null)
        {
            _screensByType[screenType].DoHide(callback: callback);
        }

        public void HideOpenedScreens(bool force, float delay)
        {
            int openedScreensCount = _openedScreens.Count;
            
            for (int i = 0; i < openedScreensCount; i++)
            {
                IScreen openedScreen = _openedScreens.Pop();
                openedScreen.DoHide(force, delay);
            }
        }

        private void HideScreen(IScreen screen) => screen.DoHide();
    }
}