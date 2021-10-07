using System;
using UnityEngine;
using UnityEngine.UI;

namespace myScript
{
    public class MyBird : MonoBehaviour
    {
        public static MyBird instance = null;
        [Tooltip("计分")]
        public Text countText;

        public float jumpForce = 300f;
        private Rigidbody2D bird;
        private bool isLive = true;

        private int count = 0;
        
        private void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                Destroy(gameObject);
            }
        }
        
        private void Start()
        {
            bird = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (isLive)
                {
                    Fly();
                }
                else
                {
                    isLive = true;
                    Debug.LogWarning("重新开始");
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.LogWarning($"撞到 {other.gameObject.name}");
            Die();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            count++;
            SetCount();
            MySoundManger.instance.PlayPass();
        }

        private void SetCount()
        {
            countText.text = $"count: {count.ToString()}";
        }

        public void Fly()
        {
            bird.velocity = Vector2.zero; // 每次重置, 防止越加越多，爬升太快
            bird.AddForce(Vector2.up * jumpForce);
            MySoundManger.instance.PlayFly();
            Debug.Log($"velocity {bird.velocity.ToString()}");
        }

        public void Die()
        {
            Debug.LogWarning("小鸟死亡");
            bird.velocity = Vector2.zero;
            isLive = false;
            MySoundManger.instance.PlayDie();
        }
    }
}