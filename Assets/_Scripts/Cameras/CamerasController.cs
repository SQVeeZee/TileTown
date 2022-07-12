using System;
using UnityEngine;
using Zenject;

namespace Cameras
{
    public class CamerasController
    {
        private readonly CamerasContainer m_container = null;
        
        [Inject]
        public CamerasController(
            CamerasContainer container
        )
        {
            m_container = container;
        }

        public CameraController GetCamera(ECameraId cameraId)
        {
            int count = m_container.Count;
            
            for (int i = 0; i < count; i++)
            {
                var camera = m_container[i];
                if (camera.CameraId == cameraId)
                {
                    return camera;
                }
            }

            throw new ArgumentException(cameraId.ToString());
        }
    }
}