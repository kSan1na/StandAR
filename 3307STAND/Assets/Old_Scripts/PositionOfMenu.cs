using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOfMenu : MonoBehaviour
{
    
    private Vector3 start_dist;
    private Vector3 startpos_menu;
    private Vector3 startpos_panel;
    private Vector3 currentpos_menu;
    private Vector3 currentpos_panel;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject menu;  
    void Start()
    {
     
        startpos_menu = menu.transform.position;
        startpos_panel = panel.transform.position;
        start_dist = startpos_panel - startpos_menu;
        currentpos_menu = startpos_menu;
        currentpos_panel = startpos_panel;
        
    }

    // Update is called once per frame
    void Update()
    {

        currentpos_panel = panel.transform.position;
        if ((currentpos_panel - currentpos_menu) != start_dist)
        {
            currentpos_menu = currentpos_menu + (currentpos_panel - startpos_panel);
            menu.transform.position = currentpos_menu;
            startpos_panel = currentpos_panel;
            
        }
        
    }
}
