using _Scripts.Gameplay.Level.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Level
{
    public class LevelModel: IInitializable
    {
        private readonly LevelConfigs m_levelConfigs = null;

        public int Width { get; private set; }      
        public int Height { get; private set; }      
        
        [Inject]
        public LevelModel(
            LevelConfigs levelConfigs)
        {
            m_levelConfigs = levelConfigs;
        }

        void IInitializable.Initialize()
        {
            Width = m_levelConfigs.Width;
            Height = m_levelConfigs.Height;
        }
    }
}