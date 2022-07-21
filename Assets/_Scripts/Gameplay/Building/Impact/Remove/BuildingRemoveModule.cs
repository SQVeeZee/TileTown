using JetBrains.Annotations;

namespace _Scripts.Gameplay.Building.Impact.Remove
{
    [UsedImplicitly]
    public class BuildingRemoveModule
    {
        public void RemoveBuilding(BuildingView buildingView)
        {
            buildingView.Remove();
        }
    }
}