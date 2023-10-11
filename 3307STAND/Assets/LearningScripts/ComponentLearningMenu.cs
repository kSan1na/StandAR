using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentLearningMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainLearnMenu;
    [SerializeField] private GameObject LearnCompPanel;
    public void MainMenu()
    {
        MainLearnMenu.SetActive(false);
        LearnCompPanel.SetActive(true);
    }

    public void LearnMenu()
    {
        MainLearnMenu.SetActive(true);
        LearnCompPanel.SetActive(false);
    }
}
