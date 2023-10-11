using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentMenusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Conv1Menu;
    [SerializeField] private GameObject Conv2Menu;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject BunckerMenu;
    private GameObject currentMenu;
    public void SwapMenu(int flag)
    {
        switch (flag)
        {
            case (1):
                Conv1Menu.SetActive(true);
                MainMenu.SetActive(false);
                currentMenu = Conv1Menu;
                break;
            case (2):
                currentMenu = Conv2Menu;
                Conv2Menu.SetActive(true);
                MainMenu.SetActive(false);
                break;
            case 3:
                currentMenu = BunckerMenu;
                BunckerMenu.SetActive(true);
                MainMenu.SetActive(false);
                break;
            case 0:
                currentMenu.SetActive(false);
                MainMenu.SetActive(true);
                break;

        }
    }
}
