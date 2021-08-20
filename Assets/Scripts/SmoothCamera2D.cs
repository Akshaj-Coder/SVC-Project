using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SmoothCamera2D : MonoBehaviour
{
    // Start is called before the first frame update

    public float m_DampTime = 10f;
    public Transform m_Target;
    public float m_XOffset = 0;
    public float m_YOffset = 0;

    public float margin = 0.1f;


    void Start()
    {
        if (m_Target == null) 
        {
            m_Target = GameObject.FindGameObjectWithTag("Player").transform;

        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Target) 
        {
            float targetX = m_Target.position.x + m_XOffset;
            float targetY = m_Target.position.y + m_YOffset;

            if (Mathf.Abs(transform.position.x - targetX) > margin)
            targetX = Mathf.Lerp(transform.position.x,targetX,1/m_DampTime * Time.deltaTime);

            if (Mathf.Abs(transform.position.y - targetY) > margin)
            targetY = Mathf.Lerp(transform.position.y,targetY, m_DampTime * Time.deltaTime);

            transform.position = new Vector3(targetX,targetY, transform.position.z);
        }
    }

}
