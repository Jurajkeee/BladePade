using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GOTOMenu : MonoBehaviour {

    public void GOTO()
    {
        Debug.Log(this.name + "Manual Trigger");
        SceneManager.LoadScene(0);
    }
}
