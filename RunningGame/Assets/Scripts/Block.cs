using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    public float cubeCoolTimer = 0;//底下方块的冷却时间
    public float enemyCoolTimer = 0;//敌人的冷却时间

    public Transform cubeBlock;//方块
    public Transform enemy1;
    public Transform enemy2;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemyCoolTimer += Time.deltaTime;
        cubeCoolTimer += Time.deltaTime;
        if (cubeCoolTimer >= Random .Range (2.0f,4.0f))
        {
            CreateCubeBlock();
            cubeCoolTimer = 0;
        }
        int i=Random .Range (1,3);//随机出现敌人的序号
        if (enemyCoolTimer >= 7.0f)
        {
            CreateEnemy(i);
            enemyCoolTimer = 0;
        }
    }
    /// <summary>
    /// 创建方块
    /// </summary>
    void  CreateCubeBlock()
    {
        Transform cube = Instantiate(cubeBlock, transform.position, transform.rotation) as Transform;
        cube.parent = this.transform;
        cube.localScale = new Vector2(0.2f, Random.Range(0.8f, 1.2f));
    }
    /// <summary>
    /// 根据序号创建敌人
    /// </summary>
    /// <param name="i"></param>
    void CreateEnemy(int i)
    {
        switch (i)
        { 
            case 1:
                InitObj(enemy1);
                break;
            case 2:
                InitObj(enemy2);
                break;
        }
    }
    /// <summary>
    /// 实例化敌人
    /// </summary>
    /// <param name="obj"></param>
    void InitObj(Transform obj)
    {
        Transform go = Instantiate(obj, new Vector2 (transform .position .x,Random .Range (-1.5f,1.2f)), Quaternion.identity)as Transform;
        go.parent = this.transform;
    }
}
