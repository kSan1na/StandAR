using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartProgram : MonoBehaviour
{

    private Vector3 StartPosition;
    private Vector3 HMIStartPosition;
    [SerializeField] private GameObject Stand;
    [SerializeField] private GameObject HMI;
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject LearnMenu;
    [SerializeField] private GameObject WildMenu;
    private bool FirstStart = true;
    public void StartProg()
    {
        if (FirstStart)
        {
            Stand.SetActive(true);
            HMI.SetActive(true);
            StartPosition = Stand.transform.position;
            HMIStartPosition = HMI.transform.position;
            FirstStart = false;
        }
        else
        {
            Stand.transform.position = StartPosition;
            HMI.transform.position = HMIStartPosition;

        }
    }
    public void BackToStartMenu() {
        WildMenu.SetActive(false);
        LearnMenu.SetActive(false);
        StartMenu.SetActive(true);
    }

}
