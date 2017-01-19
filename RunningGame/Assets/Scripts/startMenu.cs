using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class startMenu : MonoBehaviour {

    private Image imageRankList;

    void Start()
    {
    imageRankList =transform .Find ("Image_ranklist").GetComponent <Image >();
    }


    public void TransformScene()
    {
            Application.LoadLevel(1);
    }

    public void ShowRanklist()
    {
        imageRankList.gameObject.SetActive(true);
    }

    public void CloseRanklist()
    {
        imageRankList.gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
