using System;
using UnityEngine;

namespace myScript
{
    public class MyGameController : MonoBehaviour
    {
        public static MyGameController instance = null;

        [Tooltip("管道预制件")]
        public GameObject pipePrefabs;

        [Tooltip(" 管道产生的频率，每几秒产生一个")]
        public float createPipesRate = 3f;

        [Tooltip("管道中心位置的y最小值")]
        public float minPipPosY = -1f;

        [Tooltip("管道中心位置的y最大值")]
        public float maxPipPosY = 4f;

        [Tooltip("初始化管道的位置，x最好为负数不可见位置")]
        public Vector2 startPipPos = new Vector2(-12f, 0f);

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        
        private void Start()
        {
            InitPipesPool();
        }
        
        
        // 初始化管道缓存池
        private void InitPipesPool() {
            // for (int i = 0; i < PIPESTOTAL; ++i) {
            //     GameObject obj = Instantiate(pipesPrefabs, startPipPos, Quaternion.identity);
            //     pipes.Add(obj);
            // }
        }
    }
}