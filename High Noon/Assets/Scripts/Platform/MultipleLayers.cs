using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleLayers : MonoBehaviour {

    void Awake()
    {
        var layer2 = LayerMask.NameToLayer("Platform");
        var layer1 = LayerMask.NameToLayer("Collidable");

        int layermask1 = 1 << layer1;
        int layermask2 = 1 << layer2;

        int finalmask = layermask1 | layermask2;
    }
}
