using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITEXT : MonoBehaviour
{
    public Text Health;
    public Text OCollectable;
    public Text DCollectable;
    public intScriptable playerHealth;
    public intScriptable DylanCollectable;
    public intScriptable OwenCollectable;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth.Value = playerHealth.MaxValue; 
    }

    // Update is called once per frame
    void Update()
    {
        Health.text = playerHealth.Value.ToString();
        OCollectable.text = OwenCollectable.Value.ToString();
        DCollectable.text = DylanCollectable.Value.ToString();
        if (playerHealth.Value <= 0)
        {
        

        }
        
    }
}
