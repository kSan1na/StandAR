using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentStudy : MonoBehaviour
{
    [SerializeField] private GameObject bnk;
    [SerializeField] private GameObject cnv1;
    [SerializeField] private GameObject cnv2;
    [SerializeField] private GameObject controlCab;
    [SerializeField] private GameObject frequencyConverters;
    private int currentQustion;
    private List<int> questions = new List<int>() { 0, 1,2,3,4 };
    [SerializeField] private GameObject resultOfTest;
    [SerializeField] private GameObject testingPanelText;

    /*public void StartStudy()
    {
        bnkToolTip.SetActive(true);
        cnvToolTip_1.SetActive(true);
        cnvToolTip_2.SetActive(true);
        controlCabToolTip.SetActive(true);
        frequencyConvertersToolTip.SetActive(true);
    }
    public void StopStudy()
    {
        bnkToolTip.SetActive(false);
        cnvToolTip_1.SetActive(false);
        cnvToolTip_2.SetActive(false);
        controlCabToolTip.SetActive(false);
        frequencyConvertersToolTip.SetActive(false);
    }*/
    public void CheckAnsv(int ans)
    {
        Debug.Log(ans + " " + currentQustion);
        if (ans == currentQustion){
            
            TextUpdate(5);
        }
        else{
            questions= new List<int>() { 0, 1, 2, 3, 4 };
           
            TextUpdate(6);
        }
        InteracteSwith(false);

    }
    public void QuestionChoose()
    {
        if (questions.Count != 0)
        {
            var random = new System.Random();
            int currentQustionNum = random.Next(0, questions.Count);
            currentQustion = questions[currentQustionNum];
            Debug.Log("len=" + questions.Count);
            questions.Remove(currentQustion);
            Debug.Log(currentQustion);
            TextUpdate(currentQustion);
            InteracteSwith(true);
        }
        else {
            testingPanelText.GetComponent<TMPro.TextMeshPro>().text = "Тест пройден";
        }
    }
    private void TextUpdate(int num)
    {
        switch (num)
        {
            case (0):
                testingPanelText.GetComponent<TMPro.TextMeshPro>().text = "Найдите бункер" ;
                break;
            case (1):
                testingPanelText.GetComponent<TMPro.TextMeshPro>().text = "Найдите первый конвеер";
                break;
            case (2):
                testingPanelText.GetComponent<TMPro.TextMeshPro>().text = "Найдите второй конвеер";
                break;
            case (3):
                testingPanelText.GetComponent<TMPro.TextMeshPro>().text = "Найдите частотный преобразователь";
                break;
            case (4):
                testingPanelText.GetComponent<TMPro.TextMeshPro>().text = "Найдите Шкаф управления";
                break;
            case (5):
                testingPanelText.GetComponent<TMPro.TextMeshPro>().text = "Правильный ответ";
                break;
            case (6):
                testingPanelText.GetComponent<TMPro.TextMeshPro>().text = "Неправильный ответ";
                break;
        }

    }
    public void InteracteSwith(bool flag)
    {
        bnk.GetComponent<Microsoft.MixedReality.Toolkit.UI.Interactable>().enabled = flag;
        cnv1.GetComponent<Microsoft.MixedReality.Toolkit.UI.Interactable>().enabled = flag;
        cnv2.GetComponent<Microsoft.MixedReality.Toolkit.UI.Interactable>().enabled = flag;
        frequencyConverters.GetComponent<Microsoft.MixedReality.Toolkit.UI.Interactable>().enabled = flag;
        controlCab.GetComponent<Microsoft.MixedReality.Toolkit.UI.Interactable>().enabled = flag;
    }
}
