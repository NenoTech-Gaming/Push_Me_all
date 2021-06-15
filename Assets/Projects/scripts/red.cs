using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class red : MonoBehaviour
{
    public ColorEnum m_CharctorColor;
    // Start is called before the first frame update
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
}
