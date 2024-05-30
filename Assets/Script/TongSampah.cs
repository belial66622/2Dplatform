using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TongSampah : MonoBehaviour
{
    public int SampahDiLevel;

    [SerializeField]
    TextMeshProUGUI text;

    public int sampahTerkumpul { get; private set; } = 0;
    [SerializeField]
    int levelDituju;


    // Start is called before the first frame update
    void Start()
    {
        text.SetText($"{sampahTerkumpul}/{SampahDiLevel}");
    }

    public void SampahDiambil()
    {
        sampahTerkumpul++;

        text.SetText($"{sampahTerkumpul}/{SampahDiLevel}");
    }

    public void PindahLevel()
    {
        if (sampahTerkumpul >= SampahDiLevel)
        {
            SceneManager.LoadScene(levelDituju);
        }
    }


}
