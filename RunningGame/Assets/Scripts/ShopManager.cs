using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    public static  int fasterCount=1;
    public static  int protectionCount=1;

    private Text input_faster;
    private Text input_protection;

    public static bool isOnClick = false;

    void Start()
    {
        input_faster = transform.Find("InputField_faster/Text").GetComponent<Text>();
        
        input_protection = transform.Find("InputField_protection/Text").GetComponent<Text>();
    }

    public void OnClickButtonBuy()
    {
        isOnClick = true;
       // fasterCount = int.Parse(input_faster.text);
       // protectionCount = int.Parse(input_protection.text);
        CalculBuyFaster();
       CalculBuyProtection();
    }

    public void CalculBuyFaster()
    {
        if (input_faster.text == "")
        {
            print(1111);
            return;
        }
        else
        {
            if (GameManager.instance.money < 29) return;
            int fasterCounts = int.Parse(input_faster.text);
            if (GameManager.instance.money - fasterCounts * 30 >= 0)
            {
                GameManager.instance.money = GameManager.instance.money - fasterCounts * 30;
                print(GameManager.instance.money);
                fasterCount += fasterCounts;
            }
            else return;
        }

        
    }

    private void CalculBuyProtection()
    {
        if (input_protection.text == "")
        {
            print(1111);
            return;
        }
        else
        {
            if (GameManager.instance.money < 49) return;
            int protectionCounts = int.Parse(input_protection .text);
            if (GameManager.instance.money - protectionCounts * 50 >= 0)
            {
                GameManager.instance.money = GameManager.instance.money - protectionCounts * 50;
                print(GameManager.instance.money);
                protectionCount += protectionCounts;
            }
            else return;
        }
    }
}
