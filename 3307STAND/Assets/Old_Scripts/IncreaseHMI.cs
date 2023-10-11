using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHMI : MonoBehaviour
{
    private Vector3 currentPos;
    private Vector3 currentScale;
    private bool isIncrease = false;
    [SerializeField] private GameObject HMI;
    private Vector3 HMIPos;
    private Vector3 HMIScale;
    public void Increase()
    {
        if (!isIncrease)
        {
            currentPos = gameObject.transform.position;
            currentScale = gameObject.transform.localScale;
            gameObject.transform.localScale = currentScale * 2;
            gameObject.transform.position += new Vector3(0, 0, -0.2f);
            HMIPos = HMI.transform.position;
            HMIScale = HMI.transform.localScale;
            HMI.transform.localScale = HMIScale * 2;
            HMI.transform.position += new Vector3(0, 0, -0.2f);
            gameObject.GetComponent<PositionOfMenu>().enabled = false;
        }
        else
        {
            gameObject.transform.position = currentPos;
            gameObject.transform.localScale = currentScale;
            HMI.transform.position = HMIPos;
            HMI.transform.localScale = HMIScale;
            gameObject.GetComponent<PositionOfMenu>().enabled = true;
        }
        isIncrease = !isIncrease;
    }

}
