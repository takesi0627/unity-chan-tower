using UnityEngine;

namespace UTTower.Core
{
    public class UnityChanSpawner : MonoBehaviour
    {
        /// <summary>
        /// ColliderとRigidBodyがついてるブロックのプレハブ 
        /// </summary>
        public GameObject blockPrefab;
        
        /// <summary>
        /// Unity-chanのプレハブの配列
        /// </summary>
        public GameObject[] UnityChanPrefabs;

        /// <summary>
        /// Unity-chanを生成する間隔
        /// </summary>
        public float SpawnInterval = 1.0f;

        /// <summary>
        /// Unity-chanの初期位置の高さ
        /// </summary>
        public float SpawnHeight = 10.0f;

        private float timer; // 経過時間を計測するタイマー

        private void Update()
        {
            // 経過時間を加算
            timer += Time.deltaTime;

            // 一定時間経過したら、Unity-chanを生成する
            if (!(timer >= SpawnInterval)) return;
            
            // Unity-chanをランダムに選択して生成
            var index = Random.Range(0, UnityChanPrefabs.Length);

            var block = Instantiate(blockPrefab, transform);
            var unityChan = Instantiate(UnityChanPrefabs[index], block.transform);

            // タイマーをリセット
            timer = 0.0f;
        }
    }
}