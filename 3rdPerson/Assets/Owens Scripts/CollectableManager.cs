using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour, IAddScore
{
    [SerializeField]
    intScriptable DylansCollectables;
    [SerializeField]
    intScriptable OwensCollectables;

    void Start()
    {
        Cursor.visible = false;
        DylansCollectables.Value = 0;
        OwensCollectables.Value = 0;
    }

    public void addScoreDylan()
    {
        DylansCollectables.Value++;
    }
    public void addScoreOwen()
    {
        OwensCollectables.Value++;
    }
}
