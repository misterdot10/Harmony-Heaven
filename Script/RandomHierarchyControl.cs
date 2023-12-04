using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHierarchyControl : MonoBehaviour
{
    public List<GameObject> objectsToControl; // Objek-objek yang akan dikontrol
    private GameObject activeObject; // Objek yang diaktifkan

    private void Start()
    {
        // Pastikan ada setidaknya satu objek yang akan dikontrol
        if (objectsToControl.Count == 0)
        {
            Debug.LogError("Tidak ada objek yang akan dikontrol.");
            return;
        }

        // Pilih secara acak satu objek untuk diaktifkan
        int randomIndexToActivate = Random.Range(0, objectsToControl.Count);
        activeObject = objectsToControl[randomIndexToActivate];

        // Matikan objek yang telah dipilih
        foreach (var obj in objectsToControl)
        {
            obj.SetActive(obj == activeObject);
        }
    }
}