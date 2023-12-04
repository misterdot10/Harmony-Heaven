using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedHierarchyController : MonoBehaviour
{
    public Transform[] hierarchyRoots; // Objek-objek yang akan diatur dalam hierarki
    public float interval = 5.0f; // Interval waktu untuk mengaktifkan/menonaktifkan hirarki
    private bool isHierarchyActive = false; // Status awal adalah nonaktif

    private void Start()
    {
        // Mulai dengan mematikan hirarki pada awal permainan
        SetHierarchyActive(false);
        // Jalankan coroutine untuk mengubah status hirarki setiap interval
        StartCoroutine(ToggleHierarchy());
    }

    private IEnumerator ToggleHierarchy()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            isHierarchyActive = !isHierarchyActive; // Toggle status aktif/tidak aktif
            SetHierarchyActive(isHierarchyActive);
        }
    }

    public void SetHierarchyActive(bool isActive)
    {
        foreach (Transform root in hierarchyRoots)
        {
            if (root != null)
            {
                root.gameObject.SetActive(isActive); // Mengaktifkan atau menonaktifkan hirarki
            }
        }
    }
}
