using Assets.Script.Cam;
using UnityEngine;

namespace Assets.Script.UI
{
    public class Background: MonoBehaviour
    {
        private Material _material;
        private Vector2 _offset;

        [field: SerializeField]
        public GameCamera Camera { get; set; }

        private Vector3 _lastPos;
        private float _speed;

        private void Start()
        {
            _material = GetComponent<Renderer>().material;
            _lastPos = transform.position;
        }

        private void Update()
        {
            _offset = new Vector2(_speed, 0);
            _material.mainTextureOffset += _offset * Time.deltaTime;
        }

        private void LateUpdate()
        {
            MoveWithCamera();
        }

        private void MoveWithCamera()
        {
            transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, transform.position.z);

            _speed = (transform.position - _lastPos).magnitude;
            _lastPos = transform.position;
        }
    }
}
