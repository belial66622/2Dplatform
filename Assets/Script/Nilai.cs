using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Nilai : TongSampah
{
    protected override void Start()
    {
        text.SetText($"{sampahTerkumpul}");
    }

    public override void SampahDiambil()
    {
        sampahTerkumpul++;

        text.SetText($"{(float)((float)sampahTerkumpul/(float)SampahDiLevel)*100}");
        if(sampahTerkumpul == SampahDiLevel) 
        {
            OnFull?.Invoke();
        }
    }

}
