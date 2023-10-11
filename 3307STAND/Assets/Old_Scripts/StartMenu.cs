using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject LearnMenu;
    [SerializeField] private GameObject WildMenu;
    [SerializeField] private GameObject StartMen;
    private GameObject CurrentMenu;
    public void SwapMenu(int flag)
    {
        switch (flag)
        {
            case (2):
                LearnMenu.SetActive(true);
                StartMen.SetActive(false);
                CurrentMenu = LearnMenu;
                break;
            case (1):
                CurrentMenu = WildMenu;
                WildMenu.SetActive(true);
                StartMen.SetActive(false);
                break;

        }
    }
}
