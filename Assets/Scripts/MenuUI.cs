using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Text nameText;
    private DataSaving dataSavingScript;

    // Start is called before the first frame update
    void Start()
    {
        dataSavingScript = FindObjectOfType<DataSaving>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMain()
    {
        dataSavingScript.playerName = nameText.text;
        SceneManager.LoadScene("main");
    }
    public void Exit()
    {
#if (UNITY_EDITOR)
    EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }


}
