using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float waitAfterDying = 0.5f;

    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        
    }

    public void PlayerDied()
    {
        StartCoroutine("PlayerDiedCo");
    }
    public IEnumerator PlayerDiedCo()
    {
        yield return new WaitForSeconds(waitAfterDying);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
