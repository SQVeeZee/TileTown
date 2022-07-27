using System;
using Zenject;

namespace _Scripts.Cameras
{
    public class CamerasController
    {
        private readonly CamerasContainer _container = null;
        
        [Inject]
        public CamerasController(
            CamerasContainer container
        )
        {
            _container = container;
        }

        public CameraController GetCamera(ECameraId cameraId)
        {
            int count = _container.Count;
            
            for (int i = 0; i < count; i++)
            {
                var camera = _container[i];
                if (camera.CameraId == cameraId)
                {
                    return camera;
                }
            }

            throw new ArgumentException(cameraId.ToString());
        }
    }
}