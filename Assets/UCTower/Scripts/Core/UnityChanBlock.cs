using System;
using UCTower.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UCTower.Core
{
    [RequireComponent(typeof(Rigidbody))]
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

        private Rigidbody _rigidbody;
        
        private void Awake()
        {
            var index = Random.Range(0, unityChanPrefabs.Length);
            _unityChan = Instantiate(unityChanPrefabs[index], transform);
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(TagDefine.Ground) || collision.gameObject.CompareTag(TagDefine.Block))
            {
                BlockState = EBlockState.Grounded;
            }
        }

        // Update is called once per frame
        private void Update()
        {
            if (BlockState == EBlockState.WaitForTap)
            {
                // Move right to left
            }
            
            if (_rigidbody.useGravity && BlockState == EBlockState.WaitForTap)
            {
                BlockState = EBlockState.Falling;
            }
        }
    }
}
