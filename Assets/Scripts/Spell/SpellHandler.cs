using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHandler : MonoBehaviour
{
    [SerializeField] private SpellBase spell;
    private float time = 0.0f;

    void Start()
    {
        if (spell != null)
            spell.Initialize(GetComponent<FairyController>());
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= spell.Interval)
        {
            time = 0.0f;
            spell.DoSpell(GetComponent<FairyController>());
        }
    }


}