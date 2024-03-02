using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class Startup : MonoBehaviour
{
    [SerializeField] PlayableDirector timeline;
    [SerializeField] GameObject startup;
    [SerializeField] GameObject game;
    [SerializeField] TextMeshProUGUI wakeup;

    [SerializeField] Texture2D cursorTexture;
    [SerializeField] CursorMode cursorMode = CursorMode.Auto;
    [SerializeField] Vector2 hotSpot = Vector2.zero;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update() 
    {
        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if (rayHit && wakeup.color.a >= 0.1) 
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
        else if (wakeup.color.a >= 0.1)
        {
            Cursor.SetCursor(null, hotSpot, cursorMode);
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (! context.started) return;

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (! rayHit.collider) return;

        game.SetActive(true);          
        startup.SetActive(false);
    }
}

