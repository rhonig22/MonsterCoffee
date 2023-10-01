using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenUXManager : MonoBehaviour
{
    public void PlayClicked()
    {
        SceneManager.LoadScene("CafeScene");
    }
}
