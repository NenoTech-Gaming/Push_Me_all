using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    [SerializeField] public Transform m_TargetRoot;
    [SerializeField] public Animator m_Animator;
    [SerializeField] public Transform m_Target;
    [SerializeField] public float m_MoveSpeed;
    [SerializeField] public List<Transform> m_Slots = new List<Transform>();
    [SerializeField] private Transform m_BricksRoot;
    [SerializeField] bool isgrounded;
    public ColorEnum m_CharctorColor;

    private void Start()
    {
        SetCharactorColor();
    }
   
    [Button]
    void SetCharactorColor()
    {
        switch (m_CharctorColor)
        {
            case ColorEnum.GREEN:
                SetColor(Color.green);
                break;
            case ColorEnum.RED:
                SetColor(Color.red);
                break;
            case ColorEnum.YELLOW:
                SetColor(Color.yellow);
                break;
            default:
                SetColor(Color.white);
                break;
        }
    }
        void SetColor(Color i_Color)
        {
          transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color = i_Color;
        }

    public ColorEnum SetPlayreEnum()
    {
        return m_CharctorColor;
    }

    void FixedUpdate()
    {

        if (isgrounded== true)
        {
            Debug.Log("IS_GROUND_TRUEE");
        }

        if (Input.GetMouseButton(0))    
        {
            if (Vector3.Distance(m_Target.position, transform.position) > 0.15f || true)
            {
                transform.LookAt(m_Target);
                m_TargetRoot.position = transform.position;
                transform.Translate((Vector3.forward) * Time.deltaTime * (m_MoveSpeed));
                m_Animator.enabled = true;
            }
            else
            {
                m_Animator.enabled = false;
            }
        }
        else
        {
            m_Animator.enabled = false;
        }
    }
 
}

