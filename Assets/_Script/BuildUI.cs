using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildUI : MonoBehaviour
{
    public readonly Vector3 offset = new Vector3(0f, -10f,0f);

    [SerializeField] private Button confirm;
    [SerializeField] private Button rotate;
    [SerializeField] private Button cancel;

    private void Start()
    {
        confirm.onClick.AddListener(delegate { BuildManager.Instance.SetState(BuildManager.BuildState.endBuild); });
        rotate.onClick.AddListener(delegate { BuildManager.Instance.SetState(BuildManager.BuildState.rotate); });
        cancel.onClick.AddListener(BuildManager.Instance.EndBuild);
    }
   
   
}
