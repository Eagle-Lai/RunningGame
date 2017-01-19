using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject protectionZone;//保护罩显示
    Rigidbody2D rd;
    public  bool isProtection;//是否处于保护状态

    public static  int score;//用于保存分数

    public GameObject gameOver;//游戏结束的界面

	// Use this for initialization
	void Start () {
        rd = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Jump()
    {
        rd.AddForce(new Vector2(0, 250));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //处于保护状态事，销毁碰到的物体
        if (isProtection)
        {
            if (other.gameObject.tag == "Block")
            {
                Destroy(other.gameObject);
            }
        }
        //碰到底部的时候，更新跳起计数
        if (other.gameObject.tag == "botton")
        {
            GameManager.instance.jumpNumber = 0;
        }
        //当不在保护状态时，销毁自己
        if (!isProtection)
        {           
            if (other.gameObject.tag == "Block")
            {
                //保存分数，用于排名显示
                gameOver.SetActive(true);
                int temp = GameManager.instance.sorce;
                score = PlayerPrefs.GetInt("score", temp);
                Destroy(this.gameObject);
            }
        }
    }
}
