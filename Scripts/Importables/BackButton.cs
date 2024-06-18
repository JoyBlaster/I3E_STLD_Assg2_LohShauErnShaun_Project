using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField]
    private AudioSource buttonSelect;

    public void Return()
    {
        buttonSelect.Play();
    }
}
