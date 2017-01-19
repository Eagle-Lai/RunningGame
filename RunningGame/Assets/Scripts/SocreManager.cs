using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SocreManager : MonoBehaviour {

    private int score=0;//分数
    private int temp=0;

    private Text text0;//no.1
    private Text text1;//no.2

	// Use this for initialization
	void Start () {
        text0 = transform.Find("Text0").GetComponent<Text>();
        text1 = transform.Find("Text1").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        GetSorce();
        CompareScore();
	}


    public void GetSorce()
    {
        score = PlayerController.score;
    }

    /// <summary>
    /// 排名
    /// </summary>
    public void CompareScore()
    {
        
        if (temp < score)
        {
            temp = score;
            text0.text = "No.1  Score:" + temp;
            text1.text = "No.2  Score:" + score;
        }
        else
        {
            text0.text = "No.1  Score:" + score;
            text1.text = "No.2  Score:" + temp;
        }
    }
}
