using UnityEngine;

public class ProgressBarController : MonoBehaviour
{
    public RectTransform progressBar;
    public RectTransform progressIndicator;
    public Transform player;

    private float goal = 10000f; // The goal

    private void Update()
    {
        UpdateProgressBar();
    }

    private void UpdateProgressBar()
    {
        // Calculate the percentage of player's movement
        float playerProcentage = Mathf.Clamp01(player.position.x / goal);

        // Calculate the percentage of the progress bar
        float movementProcentage = progressBar.rect.width * playerProcentage;

        // Move the progress indicator to the target position
        progressIndicator.anchoredPosition = new Vector2(movementProcentage, progressIndicator.anchoredPosition.y);
    }
}