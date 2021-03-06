﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float minimumDistance = .2f;
    private float maximumTime = 1;

    private InputControl inputControl;

    private Vector3 startPosition;
    private float startTime;
    private Vector3 endPosition;
    private float endTime;
    private LineRenderer lineRenderer;
    public Material mat;

    private SwipeMessage swipeMessage;
    private V3 v3;

    private void Awake()
    {
        inputControl = Character.Instance.inputControl;
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.SetPositions(new Vector3[] { new Vector2(0, 0), new Vector2(0, 100) });
        v3 = new V3();
        v3.x = 0;
        v3.y = 0;
        v3.z = 0;
        swipeMessage = new SwipeMessage();
        
    }
    private void OnEnable()
    {
        /*inputControl.Normal.Swipe.started += SwipeStart;
        inputControl.Normal.Swipe.canceled += SwipeEnd;*/
        inputControl.Swipe.Touch.started += OnTouchStart;
        inputControl.Swipe.Touch.canceled += OnTouchEnd;

    }



    private void OnTouchStart(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Touch start");
        SwipeStart();
    }
    private void OnTouchEnd(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Touch end");
        SwipeEnd();
    }

    private void OnDisable()
    {
        inputControl.Swipe.Touch.started -= OnTouchStart;
        inputControl.Swipe.Touch.canceled -= OnTouchEnd;
    }



    private void SwipeStart()
    {
        endTime = Time.fixedTime;
        startPosition = inputControl.Swipe.Position.ReadValue<Vector2>();
        startPosition.z = CameraController.Instance.dCamera.nearClipPlane;

        /*startPosition.x /=Screen.width;
        startPosition.y /=Screen.height;*/
        Debug.Log("Swipe start" + startPosition.ToString());
    }
    private void SwipeEnd()
    {
        startTime = Time.fixedTime;
        endPosition = inputControl.Swipe.Position.ReadValue<Vector2>();
        endPosition.z = CameraController.Instance.dCamera.nearClipPlane;

        //endPosition.z=-1;
        Debug.Log("Swipe end" + endPosition.ToString());
        DetectSwipe();
    }

    private async void DetectSwipe()
    {
        //  if (Vector3.Distance(startPosition, endPosition) >= minimumDistance && (endTime - startTime) <= maximumTime)
        //  {
        //Debug.DrawLine(startPosition, endPosition, Color.red,2,false);

        float dy = startPosition.y - endPosition.y;
        float dX = endPosition.x - startPosition.x;

        float rads = Mathf.Atan2(dy, dX);

        float degrees = rads;
        degrees *= -1;


        Vector3 inWorldPosA = CameraController.Instance.dCamera.ScreenToWorldPoint(startPosition);
        Vector3 inWorldPosB = CameraController.Instance.dCamera.ScreenToWorldPoint(endPosition);

        Vector3 dir = (inWorldPosA - inWorldPosB).normalized;

        v3.x = dir.x;
        v3.y = dir.y;
        v3.z = dir.z;

        swipeMessage.degree = degrees;
        swipeMessage.direction=v3;
        await Character.Instance.client.room.Send("swipe", swipeMessage);
        Debug.Log("Direction-----------" );
        Debug.Log("Direction" + dir);
        Debug.Log("Direction" + inWorldPosA+" / "+inWorldPosB);
        Debug.Log("Direction" + startPosition+" / "+endPosition);
        //  }
    }



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
