using System;

namespace _Scripts.Gameplay.Building.Builder
{
    public interface IBuildingsBuilder
    {
        public event Action<IBuilding> BuildingCreated;
        IBuilding CreateBuilding(EBuildingType buildingType);
    }
}