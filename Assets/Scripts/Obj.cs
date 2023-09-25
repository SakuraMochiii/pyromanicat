using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{
    #region Animation_components
    Animator anim;
    #endregion

    #region Unity_functions
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Burn()
    {
        //change object to burning state
        anim.SetBool("Burn", true);
    }
    public void Save()
    {
        anim.SetBool("Burn", false);
    }
    #endregion
}
