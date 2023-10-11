using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class SizeManager : MonoBehaviour
{
    [SerializeField] private GameObject SizeBar;
    [SerializeField] private GameObject SizeMenu;
    [SerializeField] private GameObject Stand;
    [SerializeField] private GameObject Plane;
    float size = 0.5f;
    private Vector3 Coords;
    // Update is called once per frame
    public void OnStart()
    {
        gameObject.transform.Translate(0, 2, 0);
        Stand.GetComponent<Rigidbody>().isKinematic = true;
        Plane.GetComponent<Rigidbody>().isKinematic = true;
    }
    public void SizeCorrect()
    {
        
        size =SizeBar.GetComponent<PinchSlider>().SliderValue;
        gameObject.GetComponent<Transform>().localScale = new Vector3(size, size, size);
        
    }
    public void Stopped()
    {
        Stand.GetComponent<Rigidbody>().isKinematic = false;
        Plane.GetComponent<Rigidbody>().isKinematic = false;
    }
}
