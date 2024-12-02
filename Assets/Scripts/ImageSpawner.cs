using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ImageSpawner : MonoBehaviour
{
    public Sprite[] sprites;
    public Text header;

    void SetupSprites()
    {
        //Sprite = Resources.LoadAll("Sprites", typeof(Sprites)).Cast<Sprite>().ToArray();
    }

    void SetupText()
    {

    }

    private void Start()
    {
        SetupSprites();
        SetupText();
        foreach (var sprite in sprites)
        {
            //  SpawnImage(Item);
        }
    }

   // void SpawnImage(Spike sprite)
    //{

    //}
}
