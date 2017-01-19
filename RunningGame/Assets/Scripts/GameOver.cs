using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    public void Again()
    {
        Application.LoadLevel(1);
    }

    public void Home()
    {
        Application.LoadLevel(0);
    }
}
