using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameview : MonoBehaviour
{
    public GameObject Player;
    public GameObject Gameview;
    private bool gameview1 = false;
    private void Start()
    {
        Player.SetActive(true);
        Gameview.SetActive(false);
    }
    public void changeview()
    {
        if (gameview1 == false)
        {
            gameview1 = true;
            Player.SetActive(false);
            Gameview.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }else if (gameview1 == true)
        {
            gameview1 = false;
            Player.SetActive(true);
            Gameview.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
