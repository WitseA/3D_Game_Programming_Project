using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearPortal : MonoBehaviour
{
    public Transform player;
    public float visibilityDistance = 5.0f;

    private Renderer[] renderers;
    private Color originalColor;

    void Start()
    {
        // Verzamel alle Renderer-componenten op het GameObject
        renderers = GetComponentsInChildren<Renderer>();

        // Bewaar de oorspronkelijke kleur voor later gebruik
        originalColor = renderers[0].material.color;

        // Update de zichtbaarheid bij het starten van het spel
        UpdateVisibility();
    }

    void Update()
    {
        // Voer hier andere logica uit als dat nodig is

        // Update de zichtbaarheid op basis van de afstand tot de speler
        UpdateVisibility();
    }

    void UpdateVisibility()
    {
        if (player == null)
        {
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Maak de materialen transparant of ondoorzichtig op basis van de afstand
        bool isVisible = distanceToPlayer <= visibilityDistance;

        foreach (Renderer renderer in renderers)
        {
            Color newColor = isVisible ? originalColor : new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
            renderer.material.color = newColor;
        }
    }
}
