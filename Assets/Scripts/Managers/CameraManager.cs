using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;

    public Transform targetTransform;
    public Transform cameraTransform;
    public Transform cameraPivotTransform;

    public Transform nearestLockOnTargets;

    private Transform myTransform;
    private Vector3 cameraTransformPosition;
    //private LayerMask ignoreLayerMask;

    public static CameraManager instance;

    public float lookSpeed = 0.1f;
    public float followSpeed = 0.1f;
    public float pivotSpeed = 0.03f;

    private float defaultPosition;
    private float lookAngle;
    private float pivotAngle;

    public float minimumPivot = -35f;
    public float maximumPivot = 35f;

    public float maxLockOnDist = 30f;
    public Transform currentLockOnTarget;

    List<Character> avaliableTargets = new List<Character> ();

    private void Awake()
    {
        instance= this;
        myTransform = transform;
        defaultPosition = cameraTransform.localPosition.z;

        inputManager = FindObjectOfType<InputManager> ();
    }

    public void FollowTarget(float delta)
    {
        Vector3 targetPosition = Vector3.Lerp(myTransform.position, targetTransform.position, delta / followSpeed); //Vector3.Lerp
        myTransform.position = targetPosition;
    }
    
    public void HandleCameraRotation(float delta, float mouseXinput, float mouseYinput)
    {
        if(inputManager.lockOnFlag == false && currentLockOnTarget == null)
        {
            lookAngle += (mouseXinput * lookSpeed) / delta;
            pivotAngle -= (mouseYinput * pivotSpeed) / delta;
            pivotAngle = Mathf.Clamp(pivotAngle, minimumPivot, maximumPivot);

            Vector2 rotation = Vector3.zero;
            rotation.y = lookAngle;

            Quaternion targetRotation = Quaternion.Euler(rotation);
            myTransform.rotation = targetRotation;

            rotation = Vector3.zero;
            rotation.x = pivotAngle;

            targetRotation = Quaternion.Euler(rotation);
            cameraPivotTransform.localRotation = targetRotation;
        }
        else
        {
            Vector3 direction = currentLockOnTarget.position - transform.position;
            direction.Normalize();
            direction.y = 0;

            Quaternion targetRoattion = Quaternion.LookRotation(direction);
            transform.rotation = targetRoattion;

            direction = currentLockOnTarget.position - cameraPivotTransform.position;
            direction.Normalize();

            targetRoattion = Quaternion.LookRotation(direction);
            Vector3 eulerAngles = targetRoattion.eulerAngles;
            eulerAngles.y = 0;

            cameraPivotTransform.localEulerAngles = eulerAngles;
        }

    }

    public void HandleLockOn()
    {
        float shortestDistance = Mathf.Infinity;
        Collider[] colliders = Physics.OverlapSphere(targetTransform.position, 26); //Creates a invisible circle around the player

        for(int i=0;i<colliders.Length;i++)
        {
            Character character = colliders[i].GetComponent<Character>(); //search all colldiers detected with the chaarcter script

            if(character != null)
            {
                Vector3 locktargetDirection = character.transform.position - targetTransform.position;
                float distanceFromTarget = Vector3.Distance(targetTransform.position, character.transform.position);
                float viewableAngle = Vector3.Angle(locktargetDirection, cameraTransform.forward); //detects target only the screen

                if (character.transform.root != targetTransform.transform.root && viewableAngle > -50 && viewableAngle < -50
                    && distanceFromTarget <= maxLockOnDist)
                // does not lock on the player targets and locks within the circle and locks within the shortest distance
                {
                    avaliableTargets.Add(character);
                }
            }
        }

        for(int j=0;j<avaliableTargets.Count;j++)
        {
            float distFromTargets = Vector3.Distance(targetTransform.position, avaliableTargets[j].transform.position); //Dist bet player and enemies

            if(distFromTargets < shortestDistance)
            {
                shortestDistance = distFromTargets;
                nearestLockOnTargets = avaliableTargets[j].lockOn;
            }
        }
    }

    public void ClearLockOnTargets()
    {
        avaliableTargets.Clear();
        currentLockOnTarget = null;
        nearestLockOnTargets = null;
    }
}
