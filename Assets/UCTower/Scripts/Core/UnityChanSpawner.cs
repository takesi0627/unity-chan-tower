using UnityEngine;

namespace UCTower.Core
{
    public class UnityChanSpawner : MonoBehaviour
    {
        /// <summary>
        /// ColliderとRigidBodyがついてるブロックのプレハブ 
        /// </summary>
        public GameObject blockPrefab;
        
        private UnityChanBlock _currentBlock;
        
        private void Update()
        {
            if (!_currentBlock || _currentBlock.BlockState == UnityChanBlock.EBlockState.Grounded)
            {
                Spawn();
            }

            // ユーザーがタップしたら落とす
            if (_currentBlock.BlockState == UnityChanBlock.EBlockState.WaitForTap && Input.GetMouseButtonDown(0))
            {
                _currentBlock.GetComponent<Rigidbody>().useGravity = true;
            }
        }

        private void Spawn()
        {
            _currentBlock = Instantiate(blockPrefab, transform).GetComponent<UnityChanBlock>();
        }
    }
}