using System.Collections.Generic;
using UnityEngine;

namespace myScript
{
    public class MyGameController : MonoBehaviour
    {
        public static MyGameController instance = null;

        [Tooltip("管道预制件")]
        public GameObject pipesPrefabs;

        [Tooltip("管道产生的频率，每几秒产生一个")]
        public float createPipesRate = 3f;
        [Tooltip("管道生成的离中心点的位置")]
        public float createPipPosX = 13f;

        [Tooltip("管道中心位置的y最小值")]
        public float minPipPosY = -1f;

        [Tooltip("管道中心位置的y最大值")]
        public float maxPipPosY = 4f;

        [Tooltip("初始化管道的位置，x最好为负数不可见位置")]
        public Vector2 startPipPos = new Vector2(0f, 0f);
        
        // 上一次创建出管道的时间
        private float lastCreatePipTime = float.NegativeInfinity;
        // 缓存管道的链表，用来复用管道
        private List<GameObject> pipes = new List<GameObject>();
        // 管道缓存的个数
        private const int PIPESTOTAL = 8;
        // 当前管道下标，用来更新管道
        private int currPipesIndex = 0;

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

        private void Update()
        {
            if (lastCreatePipTime + createPipesRate < Time.time) {

                lastCreatePipTime = Time.time;

                UpdatePipesPosition();
                currPipesIndex = (currPipesIndex + 1) % PIPESTOTAL;
            }

        }
        private void UpdatePipesPosition() {
            var randomPosY = Random.Range(minPipPosY, maxPipPosY);
            var position = new Vector2(createPipPosX, randomPosY);
            if (currPipesIndex + 1 > pipes.Count)
            {
                pipes.Add(Instantiate(pipesPrefabs, position, Quaternion.identity));
            }
            else
            {
                pipes[currPipesIndex].transform.position = position;
            }
        }
        // 初始化管道缓存池
        private void InitPipesPool()
        {
            var obj = Instantiate(pipesPrefabs, startPipPos, Quaternion.identity);
            pipes.Add(obj);
        }
    }
}