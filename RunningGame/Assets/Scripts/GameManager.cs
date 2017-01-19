using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Text tScore;//分数显示的文本
    private Text tMoney;//金钱显示的文本

   public Text tFasterCount;//加速按钮上的显示文本
   public Text tProtectionCount;//保护罩按钮上的文本

    public  int sorce = 0;//分数
    public  int money = 0;//金钱
    private int fasterCount=1;//可使用的加速数量
    private int protectionCount=1;//可使用的保护罩数量

    private Image image_shop;//商店

    public int jumpNumber = 0;//跳起计算器
    PlayerController playerController;//主角对象
    public float protectionCoolTimer = 0;//保护罩有效使用时间
    public float sorceAndmoneyCoolTimer = 0;//增加分数的间隔时间

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //初始化
        image_shop = transform.Find("Image_shop").GetComponent<Image>();
        tFasterCount = GameObject.Find("Button_faster/Text").GetComponent<Text>();
        tProtectionCount = GameObject.Find("Button_protectionZone/Text").GetComponent<Text>();
        tScore = GameObject.Find("Text_sorce").GetComponent<Text>();
        tMoney = GameObject.Find("Text_money").GetComponent<Text>();
        playerController = GameObject.Find("fish2_player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //如果打开了商店
        if (ShopManager.isOnClick)
        {
            //并且进行了操作，就更新操作
            CalculUpdateToolCount();
            ShopManager.isOnClick = false;
        }
        //更新道具数量
        UpdateToolsCount();
        //更新保护罩状态
        ReChangProtectionState();
        //更新金钱显示
        UpdateMoneyShow();
        //增加金钱
        AddSorceAndMoney();

        if (Input.GetKeyDown(KeyCode.W))
            Jump();
        if (Input.GetKeyDown(KeyCode.A))
            Faster();
        if (Input.GetKeyDown(KeyCode.D))
            ChangProtectionState();
    }
    /// <summary>
    /// 跳起
    /// </summary>
    public void Jump()
    {
        jumpNumber++;//跳跃计数
        if (jumpNumber <= 2)
        {
            playerController.Jump();
        }
    }

    /// <summary>
    /// 更改保护罩的状态并计数
    /// </summary>
    public void ChangProtectionState()
    {
        if (protectionCount <= 0) return;
        protectionCount--;
        playerController.isProtection = true;
        playerController.protectionZone.transform.localPosition = new Vector3(0, 0, 0);
    }


    /// <summary>
    /// 简单的加速显示
    /// </summary>
    public void Faster()
    {
        if (fasterCount <= 0) return;
        fasterCount--;
        BGmoveBotton.speed = 14;
    }

    /// <summary>
    /// 影藏保护罩
    /// </summary>
    private void ReChangProtectionState()
    {
        //如果正在使用保护罩
        if (playerController.isProtection)
        {
            protectionCoolTimer += Time.deltaTime;
            //保护罩的使用时间
            if (protectionCoolTimer >= 5.0f)
            {
                playerController.protectionZone.transform.position = new Vector2(100, 0);
                playerController.isProtection = false;
                //加速
                BGmoveBotton.speed = 4;
                protectionCoolTimer = 0;
            }
        }
    }

    /// <summary>
    /// 更新分数和金钱
    /// </summary>
    public void AddSorceAndMoney()
    {
        sorceAndmoneyCoolTimer += Time.deltaTime;
        if (sorceAndmoneyCoolTimer >= 3.0f)
        {
            sorce += 100;
            tScore.text = "Sorce:" + sorce;
            money += 50;
            tMoney.text = "Money:" + money;
            sorceAndmoneyCoolTimer = 0;
        }
    }

    /// <summary>
    /// 显示商店
    /// </summary>
    public void ShowShop()
    {
        Time.timeScale = 0;
        image_shop.gameObject.SetActive(true);
    }

    public void CloseShopPanel()
    {
        image_shop.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    /// <summary>
    /// 购买商店的计算
    /// </summary>
    public void CalculUpdateToolCount()
    {
        fasterCount = ShopManager.fasterCount;
        protectionCount = ShopManager.protectionCount;
        //更新相关的显示，金钱和道具数量显示
        Time.timeScale = 1;
        UpdateMoneyShow();
        tFasterCount.text = fasterCount + "";
        tProtectionCount.text = protectionCount + "";
        //暂停
        Time.timeScale = 0;
    }
     
    public void UpdateMoneyShow()
    {
        tMoney.text = "Money:" + money;
    }

    public void UpdateToolsCount()
    {
        tFasterCount.text = fasterCount + "";
        tProtectionCount.text = protectionCount + "";
    }
}
