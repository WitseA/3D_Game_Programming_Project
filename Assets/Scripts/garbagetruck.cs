using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbagetruck : MonoBehaviour
{
    public GameObject vrachtwagenPrefab;  // Prefab van de vrachtwagen
    public Transform spawnPoint;          // De positie waar de vrachtwagen verschijnt
    public float snelheid = 5f;            // De snelheid van de vrachtwagen
    public float wachttijd = 2f;           // De tijd dat de vrachtwagen wacht voordat hij verdwijnt
    public Transform eindpuntObject;      // Het object dat dient als eindpunt

    private GameObject huidigeVrachtwagen;  // Het huidige vrachtwagenobject

    private void Start()
    {
        // Creëer de vrachtwagen op de spawn positie
        SpawnVrachtwagen();
    }

    private void SpawnVrachtwagen()
    {
        // Vernietig het oude vrachtwagenobject als het bestaat
        if (huidigeVrachtwagen != null)
        {
            Destroy(huidigeVrachtwagen);
        }

        // Instantiate de vrachtwagen op de spawn positie
        huidigeVrachtwagen = Instantiate(vrachtwagenPrefab, spawnPoint.position, spawnPoint.rotation);

        // Start het bewegen van de vrachtwagen
        StartCoroutine(BeweegVrachtwagen());
    }

    private IEnumerator BeweegVrachtwagen()
    {
        yield return new WaitForSeconds(wachttijd);

        while (huidigeVrachtwagen.transform.position.z < eindpuntObject.position.z)
        {
            // Beweeg de vrachtwagen naar voren totdat deze het eindpunt bereikt
            huidigeVrachtwagen.transform.Translate(Vector3.forward * snelheid * Time.deltaTime);
            yield return null;
        }

        // Vernietig het huidige vrachtwagenobject nadat het het eindpunt heeft bereikt
        Destroy(huidigeVrachtwagen);

        // Na een tijdje opnieuw spawnen
        yield return new WaitForSeconds(wachttijd);
        SpawnVrachtwagen();
    }
}
