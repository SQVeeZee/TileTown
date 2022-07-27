using UnityEngine;

namespace _Scripts.Cameras
{
    public class CameraView : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera = null;
        
        [Space]
        [SerializeField]
        private ECameraId _cameraId = ECameraId.None;


        public Camera Camera => _camera;
        public ECameraId CameraId => _cameraId;
    }
}