using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopGround : MonoBehaviour {

    private BoxCollider2D groundCollider;
    private float boxColliderWidth;
    private float moveGroundCount = 0;

	void Start() {
		// 获取碰撞体的宽度
		groundCollider = GetComponent<BoxCollider2D>();
        boxColliderWidth = groundCollider.size.x;
        moveGroundCount = GameObject.FindGameObjectsWithTag(tag).Length;
	}
	
	void Update () {
		// 当前运动的位置小于
		if (transform.position.x < -2 * boxColliderWidth) {
			transform.position = new Vector3(
                transform.position.x + moveGroundCount * boxColliderWidth,
                transform.position.y,
                transform.position.z);
        }
	}
}
