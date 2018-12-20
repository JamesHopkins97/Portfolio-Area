using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitOnClick : MonoBehaviour {
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(Quit);
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }  
}
