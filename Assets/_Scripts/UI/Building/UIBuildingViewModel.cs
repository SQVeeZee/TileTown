using System;
using System.Collections.Generic;
using _Scripts.Gameplay.Building;
using _Scripts.Gameplay.Building.Configs;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Building
{
    public class UIBuildingViewModel : MonoBehaviour
    {
        public event Action<EBuildingType> BuildingClicked = null;

        [SerializeField] private RectTransform m_transform = null;

        private UIBuildingView m_view = null;

        private BaseBuildingConfigs m_buildingConfigs = null;

        [Inject]
        public void Constructor(
            UIBuildingView view
        )
        {
            m_view = view;
        }

        public void Initialize(
            BaseBuildingConfigs buildingConfigs,
            UIBuildingConfigs viewBuildingConfigs,
            Transform parent)
        {
            m_buildingConfigs = buildingConfigs;

            m_view.Initialize(
                buildingConfigs.BuildingName,
                viewBuildingConfigs.IconColor
            );

            SetTransform(parent);

            m_view.ViewClicked += OnViewClicked;
        }

        private void OnViewClicked()
        {
            BuildingClicked?.Invoke(m_buildingConfigs.BuildingType);
        }

        private void SetTransform(Transform parent)
        {
            m_transform.SetParent(parent, false);

            m_transform.localScale = Vector3.one;
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<UIBuildingViewModel>
        {
            private List<UIBuildingViewModel> m_buildings = new List<UIBuildingViewModel>();

            public override UIBuildingViewModel Create()
            {
                var building = base.Create();

                m_buildings.Add(building);

                return building;
            }

            public void Remove(UIBuildingViewModel buildingViewModel)
            {
                m_buildings.Remove(buildingViewModel);
                buildingViewModel.Destroy();
            }
        }
    }
}