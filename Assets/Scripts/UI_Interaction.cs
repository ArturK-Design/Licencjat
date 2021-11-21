using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class UI_Interaction : MonoBehaviour
{
    public GameObject ui_canvas;
    GraphicRaycaster ui_raycaster;

    PointerEventData click_data;
    List<RaycastResult> click_results;
 
    void Start()
    {
        ui_raycaster = ui_canvas.GetComponent<GraphicRaycaster>();
        click_data = new PointerEventData(EventSystem.current);
        click_results = new List<RaycastResult>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            GetUIElementsClicked();
        }
    }

    void GetUIElementsClicked()
    {
        click_data.position = Mouse.current.position.ReadValue();
        click_results.Clear();

        ui_raycaster.Raycast(click_data, click_results);

        foreach(RaycastResult result in click_results)
        {
            GameObject ui_elemenent = result.gameObject;

            Debug.Log(ui_elemenent.name);
        }
    }
}
