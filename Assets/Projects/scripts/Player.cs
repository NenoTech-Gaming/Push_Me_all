using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] internal Character m_Character;
    public ColorEnum m_PlayerColor;
    
    Vector3 m_PreviousPosition;
    Vector3 m_dummyDelta;
    float m_MinimumDrag;
    float  MoveSensitivity = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_PreviousPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_PreviousPosition = Vector3.zero;
        }
        else if (Input.GetMouseButton(0) && m_PreviousPosition!= Vector3.zero)
        {
            m_dummyDelta = Input.mousePosition - m_PreviousPosition;
            if (Vector3.Magnitude(m_dummyDelta) > m_MinimumDrag)
            {
                var Direction = new Vector3(m_dummyDelta.x, 0 ,m_dummyDelta.y);
                m_Character.m_Target.localPosition = Vector3.ClampMagnitude(Direction*10,2);                
                //m_Character.m_TargetRoot.LookAt(Direction);
            }
        }
    }
}
