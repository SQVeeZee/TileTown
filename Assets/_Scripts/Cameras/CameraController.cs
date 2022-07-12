using System;
using UnityEngine;
using Zenject;

namespace Cameras
{
    public class CameraController : IDisposable
    {
        private readonly CameraView m_view = null;
        private readonly CamerasContainer m_container = null;


        public ECameraId CameraId => m_view.CameraId;
        public Camera Camera => m_view.Camera;
        
        
        [Inject]
        public CameraController(
            CameraView view,
            CamerasContainer container
        )
        {
            m_view = view;

            m_container = container;
            container.Add(this);
        }

        void IDisposable.Dispose()
        {
            m_container.Remove(this);
        }
    }
}