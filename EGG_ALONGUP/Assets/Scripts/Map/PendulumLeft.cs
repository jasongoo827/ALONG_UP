using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumLeft : MonoBehaviour
{
    public float angle = 0;
    
    private float lerpTime = 0;
    private float speed = 2f;
    
    private void Update()
    {
        lerpTime += Time.deltaTime * speed;
        transform.rotation = CalculateMovementOfPendulum();
    }
	
    Quaternion CalculateMovementOfPendulum()
    {
        return Quaternion.Lerp(Quaternion.Euler(Vector3.left * angle), 
        	Quaternion.Euler(Vector3.right * angle), GetLerpTParam());
    }
	
    float GetLerpTParam()
    {
        return (Mathf.Sin(lerpTime) + 1) * 0.5f;
    }
}
