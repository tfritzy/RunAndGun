using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponType WeaponType;
    public Vector3 LeftHandHold;
    public Vector3 RightHandHold;
    public GameObject prefab;

    private GameObject playerLeftHand;
    private GameObject playerRightHand;
    void Start()
    {
        playerLeftHand = GameObject.Find("RightHand_CTRL_GRP");
        playerRightHand = GameObject.Find("LeftHand_CTRL_GRP");
        this.LeftHandHold = Vector3.zero;
        this.RightHandHold = Vector3.zero;
    }

    private Vector2 leftHandPos;
    private Vector2 rightHandPos;
    private float distFromBody = .3f;
    public void SetHandsLocation(
        Vector2 playerPos,
        Vector2 lookLocation)
    {
        Vector3 gunLocation = playerPos + 
                              (lookLocation - playerPos).Unit() * distFromBody; 
        float angle = Mathf.Atan((lookLocation.y - playerPos.y)  / 
                                 (lookLocation.x - playerPos.x)) *
                                 Mathf.Rad2Deg;
        Vector3 currentRotation = this.transform.rotation.eulerAngles;
        currentRotation.z = angle;
        int scaleFlip = lookLocation.x < playerPos.x ? -1 : 1;
        Vector3 scale = this.transform.localScale;
        scale.x  = Mathf.Abs(scale.x) * scaleFlip;
        this.transform.localScale = scale;
        this.transform.rotation = Quaternion.Euler(currentRotation);
        this.transform.position = gunLocation;
        this.playerLeftHand.transform.position = gunLocation + LeftHandHold;
        this.playerRightHand.transform.position = gunLocation + RightHandHold;

    }

    public void Attack()
    {

    }
}

public enum WeaponType
{
    Pistol,
}
