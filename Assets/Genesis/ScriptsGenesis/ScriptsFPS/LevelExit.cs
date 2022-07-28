using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public string nextLevel;

    public float waitToEndLevel;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine("EndLevelCo");
        }
    }

    IEnumerator EndLevelCo()
    {
        yield return new WaitForSeconds(waitToEndLevel);

        SceneManager.LoadScene("victoria");
    }
}
