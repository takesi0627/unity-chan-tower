using UCTower.Common;
using UnityEngine;

namespace UCTower.Core
{
    public class UnityChanMover : MonoBehaviour
    {
        /// <summary>
        /// Unity-chanの移動速度
        /// </summary>
        [SerializeField] private float moveSpeed = 5.0f;

        private bool isMoving; // 移動中かどうかのフラグ
        private Camera _camera;

        private Rigidbody _rigidbody;
        private int moveSign = 1;
        public void StartMove()
        {
            _rigidbody.velocity = new Vector3(moveSpeed * moveSign, 0f, 0f);
        }

        public void StopMove()
        {
            _rigidbody.velocity = Vector3.zero;
        }
        
        private void Awake()
        {
            _camera = Camera.main;
            _rigidbody = GetComponent<Rigidbody>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(TagDefine.Boundary))
            {
                moveSign *= -1;
                _rigidbody.velocity = new Vector3(moveSpeed * moveSign, 0, 0);
            }
        }
    }
}