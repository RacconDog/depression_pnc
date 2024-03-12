using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{
    [SerializeField] PlayerInput inputActions;
    [SerializeField] InteractablesManager im;
    [SerializeField] GameObject world;
    [SerializeField] float dragMultiplier;
    bool dragableState = false;

    Vector3 mouseDelta;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragableState = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            dragableState = false;
        }

        if (dragableState == true)
        {
            mouseDelta = new Vector3(Input.mousePositionDelta.x * dragMultiplier / 1000, 0, 0);

            world.transform.position += mouseDelta;
        }

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (rayHit) 
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(null, hotSpot, cursorMode);
        }

    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (! context.started) return;

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (! rayHit.collider) return;
        
        im.PlayAnim(rayHit.transform.gameObject);
    }
}
