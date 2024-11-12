using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextLevelSetup : MonoBehaviour
{

    TMP_Text mytext;

    private void Awake()
    {
        mytext = GetComponent<TMP_Text>();
        mytext.SetText(SceneManager.GetActiveScene().buildIndex.ToString());
    }
}
