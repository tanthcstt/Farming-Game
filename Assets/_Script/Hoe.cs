/*using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hoe : MonoBehaviour
{
    /// <summary>
    /// when player hoeing mud object will instantiate on base tile (grass block)
    /// </summary>
    private float maxDistance = 3f;
    public GameObject cultivatedLand_Prefabs;
    public Transform baseTile;
    private void Update()
    {
        PlayerHoeingController();
    }

    private void PlayerHoeingController()
    {
        if (!Input.GetMouseButtonDown(1)) return;
        // condition
        GameObject target = InputManager.Instance.mouseTargetingTile;
        if (target == null) return;
        if (target.CompareTag("Cultivated Land")) return;
        if (Vector3.Distance(transform.root.position, target.transform.position) > maxDistance) return;
        // hoeing
        PlayerHoeing(target);
    }
    private void PlayerHoeing(GameObject targeting)
    {
        GameObject cultivatedLand = Instantiate(cultivatedLand_Prefabs);
        Vector3 pos = new Vector3(targeting.transform.position.x, 0.5f, targeting.transform.position.z);
        cultivatedLand.transform.position = pos;
        cultivatedLand.transform.SetParent(baseTile, true);
    }

}
*/