using System;
using UCTower.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UCTower.Core
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(UnityChanMover))]
    public class UnityChanBlock : MonoBehaviour
    {
        public enum EBlockState
        {
            WaitForTap,
            Falling,
            Grounded
        }
        
        /// <summary>
        /// Unity-chanのプレハブの配列
        /// </summary>
        [SerializeField] private GameObject[] unityChanPrefabs;

        /// <summary>
        /// Unityちゃんインスタンス
        /// </summary>
        private GameObject _unityChan;

        public EBlockState BlockState { get; private set; } = EBlockState.WaitForTap;
        
        /// <summary>
        /// 着地したか
        /// </summary>
        public bool IsGrounded { get; private set; }


        private UnityChanMover _mover;
        private Rigidbody _rigidbody;
        
        private void Awake()
        {
            var index = Random.Range(0, unityChanPrefabs.Length);
            _unityChan = Instantiate(unityChanPrefabs[index], transform);
            _rigidbody = GetComponent<Rigidbody>();
            _mover = GetComponent<UnityChanMover>();
        }

        private void Start()
        {
            _mover.StartMove();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(TagDefine.Ground) || collision.gameObject.CompareTag(TagDefine.Block))
            {
                BlockState = EBlockState.Grounded;
            }
        }

        public void StopMoveAndStartFall()
        {
            _mover.StopMove();
            _rigidbody.useGravity = true;
            BlockState = EBlockState.Falling;
        }
    }
}
