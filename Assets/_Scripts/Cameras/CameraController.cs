using System;
using UnityEngine;
using Zenject;

namespace _Scripts.Cameras
{
    public class CameraController : IDisposable
    {
        private readonly CameraView _view = null;
        private readonly CamerasContainer _container = null;

        public ECameraId CameraId => _view.CameraId;
        public Camera Camera => _view.Camera;
        
        
        [Inject]
        public CameraController(
            CameraView view,
            CamerasContainer container
        )
        {
            _view = view;

            _container = container;
            container.Add(this);
        }

        void IDisposable.Dispose()
        {
            _container.Remove(this);
        }
    }
}