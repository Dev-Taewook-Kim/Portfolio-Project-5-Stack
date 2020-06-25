using System.Collections;
using System.Collections.Generic;
using Teamp2.Library.Framework.DataType;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    [Header("[Shared Variable]")]
    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableVector3 inputMousePointScreen;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableVector3 inputMousePointViewport;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableVector3 inputMousePointWorld;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableVector3 inputMousePointUnitCell;

    [Space()]
    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableVector3 inputTouch0PointScreen;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableVector3 inputTouch0PointViewport;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableVector3 inputTouch0PointWorld;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableVector3 inputTouch0PointUnitCell;

    [Space()]
    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableVector3 inputTouch1PointScreen;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableVector3 inputTouch1PointViewport;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableVector3 inputTouch1PointWorld;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableVector3 inputTouch1PointUnitCell;

    [Space()]
    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableBool inputMouseButton0Down;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableBool inputMouseButton0Up;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableBool inputMouseButton0;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableBool inputMouseButton1Down;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableBool inputMouseButton1Up;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableBool inputMouseButton1;

    [Space()]
    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableBool inputTouch0Began;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableBool inputTouch0Moved;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableBool inputTouch0Stationary;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableBool inputTouch0Ended;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableBool inputTouch0Canceled;

    [Space()]
    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableBool inputTouch1Began;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableBool inputTouch1Moved;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableBool inputTouch1Stationary;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableBool inputTouch1Ended;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableBool inputTouch1Canceled;

    [Space()]
    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableVector3 playerInputDirection;

    [SerializeField] private SharedVariableInt playerInputCount;

    [Header("[Shared Event]")]
    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedEvent eventOnMouseButton0Down;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedEvent eventOnMouseButton0Up;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedEvent eventOnMouseButton0;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedEvent eventOnMouseButton1Down;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedEvent eventOnMouseButton1Up;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedEvent eventOnMouseButton1;

    [Space()]
    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedEvent eventOnTouch0Began;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedEvent eventOnTouch0Moved;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedEvent eventOnTouch0Stationary;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedEvent eventOnTouch0Ended;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedEvent eventOnTouch0Canceled;

    [Space()]
    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedEvent eventOnInputPlayerDirection;

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            UpdateTouch0PointScreen();
            UpdateTouch0PointViewport();
            UpdateTouch0PointWorld();
            UpdateTouch0PointUnitCell();

            UpdateTouch1PointScreen();
            UpdateTouch1PointViewport();
            UpdateTouch1PointWorld();
            UpdateTouch1PointUnitCell();

            UpdateTouch0();
            UpdateTouch1();

            UpdatePlayerDirectionTouch();
            UpdatePlayerInputCount();

            UpdateTouch0Event();
            UpdatePlayerInputDirectionEvent();
        }

        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            UpdateMousePointScreen();
            UpdateMousePointViewport();
            UpdateMousePointWorld();
            UpdateMousePointUnitCell();

            UpdateMouseButton0();
            UpdateMouseButton1();

            UpdatePlayerDirectionMouse();
            UpdatePlayerInputCount();

            UpdateMouseButton0Event();
            UpdatePlayerInputDirectionEvent();
        }

        else if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            UpdateMousePointScreen();
            UpdateMousePointViewport();
            UpdateMousePointWorld();
            UpdateMousePointUnitCell();

            UpdateMouseButton0();
            UpdateMouseButton1();

            UpdatePlayerDirectionMouse();
            UpdatePlayerInputCount();

            UpdateMouseButton0Event();
            UpdatePlayerInputDirectionEvent();
        }
    }

    private void UpdateMouseButton0()
    {
        inputMouseButton0Down.Value = Input.GetMouseButtonDown(0);
        inputMouseButton0Up.Value = Input.GetMouseButtonUp(0);
        inputMouseButton0.Value = Input.GetMouseButton(0);
    }

    private void UpdateMouseButton1()
    {
        inputMouseButton1Down.Value = Input.GetMouseButtonDown(1);
        inputMouseButton1Up.Value = Input.GetMouseButtonUp(1);
        inputMouseButton1.Value = Input.GetMouseButton(1);
    }

    private void UpdateMouseButton0Event()
    {
        if (Input.GetMouseButtonDown(0))
        {
            eventOnMouseButton0Down.Raise();
        }

        else if (Input.GetMouseButton(0))
        {
            eventOnMouseButton0.Raise();
        }

        else if (Input.GetMouseButtonUp(0))
        {
            eventOnMouseButton0Up.Raise();
        }
    }

    private void UpdateTouch0Event()
    {
        if(Input.GetTouch(0).phase == TouchPhase.Began)
        {
            eventOnTouch0Began.Raise();
        }
    }

    private void UpdatePlayerInputCount()
    {
        if (playerInputDirection.Value.Equals(Vector3.zero))
            return;

        playerInputCount.Value++;
    }

    private void UpdatePlayerInputDirectionEvent()
    {
        if (playerInputDirection.Value.Equals(Vector3.zero))
            return;

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Application.platform == RuntimePlatform.Android &&
            EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;

        eventOnInputPlayerDirection.Raise();
    }

    private void UpdateTouch0()
    {
        if (Input.touchCount < 1)
            return;

        inputTouch0Began.Value = Input.GetTouch(0).phase == TouchPhase.Began;
        inputTouch0Moved.Value = Input.GetTouch(0).phase == TouchPhase.Moved;
        inputTouch0Stationary.Value = Input.GetTouch(0).phase == TouchPhase.Stationary;
        inputTouch0Ended.Value = Input.GetTouch(0).phase == TouchPhase.Ended;
        inputTouch0Canceled.Value = Input.GetTouch(0).phase == TouchPhase.Canceled;

    }

    private void UpdateTouch1()
    {
        if (Input.touchCount < 2)
            return;

        inputTouch1Began.Value = Input.GetTouch(1).phase == TouchPhase.Began;
        inputTouch1Moved.Value = Input.GetTouch(1).phase == TouchPhase.Moved;
        inputTouch1Stationary.Value = Input.GetTouch(1).phase == TouchPhase.Stationary;
        inputTouch1Ended.Value = Input.GetTouch(1).phase == TouchPhase.Ended;
        inputTouch1Canceled.Value = Input.GetTouch(1).phase == TouchPhase.Canceled;
    }

    private void UpdateTouch0PointScreen()
    {
        if (Input.touchCount < 1)
            return;

        var point = Input.GetTouch(0).position;

        point.x = Mathf.Clamp(point.x, 0f, Screen.width);
        point.y = Mathf.Clamp(point.y, 0f, Screen.height);

        inputTouch0PointScreen.Value = point;
    }

    private void UpdateTouch0PointViewport()
    {
        if (Input.touchCount < 1)
            return;

        var point = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position) * 2f - new Vector3(1f, 1f);

        point.x = Mathf.Clamp(point.x, -1f, 1f);
        point.y = Mathf.Clamp(point.y, -1f, 1f);

        inputTouch0PointViewport.Value = point;
    }

    private void UpdateTouch0PointWorld()
    {
        if (Input.touchCount < 1)
            return;

        inputTouch0PointWorld.Value = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
    }

    private void UpdateTouch0PointUnitCell()
    {
        if (Input.touchCount < 1)
            return;

        var cellPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

        cellPosition.x = Mathf.Round(cellPosition.x / 1f);
        cellPosition.y = Mathf.Round(cellPosition.y / 1f);

        inputTouch0PointUnitCell.Value = cellPosition;
    }

    private void UpdateTouch1PointScreen()
    {
        if (Input.touchCount < 2)
            return;

        var point = Input.GetTouch(1).position;

        point.x = Mathf.Clamp(point.x, 0f, Screen.width);
        point.y = Mathf.Clamp(point.y, 0f, Screen.height);

        inputTouch1PointScreen.Value = point;
    }

    private void UpdateTouch1PointViewport()
    {
        if (Input.touchCount < 2)
            return;

        var point = Camera.main.ScreenToViewportPoint(Input.GetTouch(1).position) * 2f - new Vector3(1f, 1f);

        point.x = Mathf.Clamp(point.x, -1f, 1f);
        point.y = Mathf.Clamp(point.y, -1f, 1f);

        inputTouch1PointViewport.Value = point;
    }

    private void UpdateTouch1PointWorld()
    {
        if (Input.touchCount < 2)
            return;

        inputTouch1PointWorld.Value = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position);
    }

    private void UpdateTouch1PointUnitCell()
    {
        if (Input.touchCount < 2)
            return;

        var cellPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position);

        cellPosition.x = Mathf.Round(cellPosition.x / 1f);
        cellPosition.y = Mathf.Round(cellPosition.y / 1f);

        inputTouch1PointUnitCell.Value = cellPosition;
    }

    private void UpdateMousePointScreen()
    {
        var point = Input.mousePosition;

        point.x = Mathf.Clamp(point.x, 0f, Screen.width);
        point.y = Mathf.Clamp(point.y, 0f, Screen.height);

        inputMousePointScreen.Value = point;
    }

    private void UpdateMousePointViewport()
    {
        var point = Camera.main.ScreenToViewportPoint(Input.mousePosition) * 2f - new Vector3(1f, 1f);

        point.x = Mathf.Clamp(point.x, -1f, 1f);
        point.y = Mathf.Clamp(point.y, -1f, 1f);

        inputMousePointViewport.Value = point;
    }

    private void UpdateMousePointWorld()
    {
        inputMousePointWorld.Value = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void UpdateMousePointUnitCell()
    {
        var cellPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        cellPosition.x = Mathf.Round(cellPosition.x / 1f);
        cellPosition.y = Mathf.Round(cellPosition.y / 1f);

        inputMousePointUnitCell.Value = cellPosition;
    }

    private void UpdatePlayerDirectionTouch()
    {
        if (!inputTouch0Began.Value)
        {
            playerInputDirection.Value = Vector3.zero;
            return;
        }

        if ((inputTouch0PointViewport.Value.x > 0 && inputTouch0PointViewport.Value.x < 1) && (inputTouch0PointViewport.Value.y > 0 && inputTouch0PointViewport.Value.y < 1))
            playerInputDirection.Value = Vector3.forward;

        else if ((inputTouch0PointViewport.Value.x > -1 && inputTouch0PointViewport.Value.x < 0) && (inputTouch0PointViewport.Value.y > 0 && inputTouch0PointViewport.Value.y < 1))
            playerInputDirection.Value = Vector3.left;

        else if ((inputTouch0PointViewport.Value.x > -1 && inputTouch0PointViewport.Value.x < 0) && (inputTouch0PointViewport.Value.y > -1 && inputTouch0PointViewport.Value.y < 0))
            playerInputDirection.Value = Vector3.back;

        else if ((inputTouch0PointViewport.Value.x > 0 && inputTouch0PointViewport.Value.y < 1) && (inputTouch0PointViewport.Value.y > -1 && inputTouch0PointViewport.Value.y < 0))
            playerInputDirection.Value = Vector3.right;

        else
            playerInputDirection.Value = Vector3.zero;
    }

    private void UpdatePlayerDirectionMouse()
    {
        if (!inputMouseButton0Down.Value)
        {
            playerInputDirection.Value = Vector3.zero;
            return;
        }

        if ((inputMousePointViewport.Value.x > 0 && inputMousePointViewport.Value.x < 1) && (inputMousePointViewport.Value.y > 0 && inputMousePointViewport.Value.y < 1))
            playerInputDirection.Value = Vector3.forward;

        else if ((inputMousePointViewport.Value.x > -1 && inputMousePointViewport.Value.x < 0) && (inputMousePointViewport.Value.y > 0 && inputMousePointViewport.Value.y < 1))
            playerInputDirection.Value = Vector3.left;

        else if ((inputMousePointViewport.Value.x > -1 && inputMousePointViewport.Value.x < 0) && (inputMousePointViewport.Value.y > -1 && inputMousePointViewport.Value.y < 0))
            playerInputDirection.Value = Vector3.back;

        else if ((inputMousePointViewport.Value.x > 0 && inputMousePointViewport.Value.y < 1) && (inputMousePointViewport.Value.y > -1 && inputMousePointViewport.Value.y < 0))
            playerInputDirection.Value = Vector3.right;

        else
            playerInputDirection.Value = Vector3.zero;

    }
}
