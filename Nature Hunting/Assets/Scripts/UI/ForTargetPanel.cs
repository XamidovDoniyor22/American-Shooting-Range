using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForTargetPanel : MonoBehaviour
{
    [SerializeField] private GameObject targetPanel;

    private void Start()
    {
        targetPanel.SetActive(true);
        StartCoroutine(TargetPanel());
    }

    private IEnumerator TargetPanel()
    {
        targetPanel.SetActive(true);

        yield return new WaitForSeconds(2f);

        targetPanel.SetActive(false);
    }
}
