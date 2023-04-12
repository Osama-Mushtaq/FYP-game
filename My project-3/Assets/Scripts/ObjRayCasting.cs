#region Old Code
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
//
// public class ObjRaycasting : MonoBehaviour
// {
//     public Canvas crshr;
//     private Color32 originalColor = new Color32(255, 255, 255, 255);
//     private Color32 targetColor = new Color32(127, 255, 127, 255);
//     private float waitTime = 2f;
//     private Vector3 spawnRange = new Vector3(2, 4, 5);
//
//     private bool isWaiting = false;
//     private bool isTargetObject = false;
//     public static bool canHit = false;
//     private Coroutine colorCoroutine;
//
//     void Update()
//     {
//         RaycastHit hit;
//         Physics.Raycast(transform.position, transform.forward, out hit, 50);
//         if (hit.collider.gameObject.name == "Sphere")
//         {
//
//             isTargetObject = true;
//             if (!isWaiting)
//             {
//                 colorCoroutine = StartCoroutine(WaitAndChangeColor());
//             }
//         }
//         else if (hit.collider == null || hit.collider.gameObject.name != "Sphere")
//         {
//             isTargetObject = false;
//             isWaiting = false;
//             canHit = false;
//             if (colorCoroutine != null)
//             {
//                 StopCoroutine(WaitAndChangeColor());
//             }
//             ResetColor();
//         }
//         // if ()
//         // {
//
//
//         // }
//     }
//     IEnumerator WaitAndChangeColor()
//     {
//         isWaiting = true;
//         yield return new WaitForSeconds(waitTime);
//         if (isTargetObject)
//         {
//             Transform objectTransform = crshr.transform.Find("my_crosshair");
//             Graphic objectGraphic = objectTransform.GetComponentInChildren<Graphic>();
//             objectGraphic.color = targetColor;
//             Image[] objectImages = objectTransform.GetComponentsInChildren<Image>();
//             foreach (Image image in objectImages)
//             {
//                 image.color = targetColor;
//             }
//         }
//         isWaiting = false;
//         canHit = true;
//     }
//     void ResetColor()
//     {
//         Transform objectTransform = crshr.transform.Find("my_crosshair");
//         Graphic objectGraphic = objectTransform.GetComponentInChildren<Graphic>();
//         objectGraphic.color = originalColor;
//         Image[] objectImages = objectTransform.GetComponentsInChildren<Image>();
//         foreach (Image image in objectImages)
//         {
//             image.color = originalColor;
//         }
//     }
// }
#endregion

using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ObjRayCasting : MonoBehaviour
{
    public bool CanHit { get; private set; }

    [SerializeField] private string hitName = "Sphere";
    [SerializeField] private float hitDistance = 50f;
    [SerializeField] private float waitTime = 2f;
    [SerializeField] private Image[] crossHairParts;
    [SerializeField] private Color32 originalColor = new Color32(255, 0, 0, 255);
    [SerializeField] private Color32 targetColor = new Color32(127, 255, 127, 255);

    private enum State { Idle, Waiting, On }
    private State _currentState = State.Idle, _nextState = State.Idle;
    private float _waitedTime;

    public void Reset()
    {
        CanHit = false;
        _waitedTime = 0f;
        crossHairParts.ToList().ForEach(x => x.color = originalColor);
        _currentState = State.Idle;
    }

    private bool IsHitting()
    {
        if (!Physics.Raycast(transform.position, transform.forward, out var hit, hitDistance))
            return false;
        return hit.transform.name == hitName;
    }

    private void Update()
    {
        switch (_currentState)
        {
            case State.Idle:
                if (!IsHitting()) return;
                _nextState = State.Waiting;
                break;
            case State.Waiting:
                if (!IsHitting()) _nextState = State.Idle;
                else
                {
                    if (_waitedTime < waitTime) _waitedTime += Time.deltaTime;
                    else _nextState = State.On;
                }
                break;
            case State.On:
                if (!IsHitting()) _nextState = State.Idle;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        if (_currentState == _nextState) return;
        _currentState = _nextState;
        print($"Switched to {_nextState}");

        switch (_nextState)
        {
            case State.Idle:
                Reset();
                break;
            case State.Waiting:
                break;
            case State.On:
                CanHit = true;
                _waitedTime = 0f;
                crossHairParts.ToList().ForEach(x => x.color = targetColor);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

}