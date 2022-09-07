using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinEquip : MonoBehaviour
{

    [SerializeField] private int skinIndex;
    [SerializeField] private Image selectedSkin;
    [SerializeField] private SkinManager skinManager;

    public void SkinEquiped()
    {
        
        
            if (skinManager.IsUnlocked(skinIndex))
            {
                skinManager.SelectSkin(skinIndex);
            }
        
    }
}
