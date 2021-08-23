using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField] private UnsignedIntValueSO healthValueSO;
    [SerializeField] private UnsignedIntValueSO scoreValueSO;

    [SerializeField] private int initialHealthValue;

    [SerializeField] private int meteorBigDestroyingScore;
    [SerializeField] private int meteorMediumDestroyingScore;
    [SerializeField] private int ufoDestroyingScore;
    [SerializeField] private int meteorBigBumpHealthDecrease;
    [SerializeField] private int meteorMediumBumpHealthDecrease;
    [SerializeField] private int ufoHitHealthDecrease;


    private void OnEnable()
    {
        GameEvents.onPlayerBulletCollidedWithBigMeteor += GameEvents_onPlayerBulletCollidedWithBigMeteor;
        GameEvents.onPlayerBulletCollidedWithMediumMeteor += GameEvents_onPlayerBulletCollidedWithMediumMeteor;
        GameEvents.onPlayerBulletCollidedWithUfo += GameEvents_onPlayerBulletCollidedWithUfo;
        GameEvents.onPlayerCollidedWithUfo += GameEvents_onPlayerCollidedWithUfo;
        GameEvents.onPlayerCollidedWithBigMeteor += GameEvents_onPlayerCollidedWithBigMeteor;
        GameEvents.onPlayerCollidedWithMediumMeteor += GameEvents_onPlayerCollidedWithMediumMeteor;
        GameEvents.onPlayerCollidedWithUfoBullet += GameEvents_onPlayerCollidedWithUfoBullet;

        GameEvents.onGameStart += ResetStats;
    }

    private void OnDisable()
    {
        GameEvents.onPlayerBulletCollidedWithBigMeteor -= GameEvents_onPlayerCollidedWithBigMeteor;
        GameEvents.onPlayerBulletCollidedWithMediumMeteor -= GameEvents_onPlayerBulletCollidedWithMediumMeteor;
        GameEvents.onPlayerBulletCollidedWithUfo -= GameEvents_onPlayerBulletCollidedWithUfo;
        GameEvents.onPlayerCollidedWithUfo -= GameEvents_onPlayerCollidedWithUfo;
        GameEvents.onPlayerBulletCollidedWithBigMeteor -= GameEvents_onPlayerBulletCollidedWithBigMeteor;
        GameEvents.onPlayerCollidedWithMediumMeteor -= GameEvents_onPlayerCollidedWithMediumMeteor;
        GameEvents.onPlayerCollidedWithUfoBullet -= GameEvents_onPlayerCollidedWithUfoBullet;

        GameEvents.onGameStart -= ResetStats;
    }

    private void ResetStats()
    {
        Debug.Log("ResetStats");
        healthValueSO.SetValue(initialHealthValue);
        scoreValueSO.SetValue(0);
    }
    private void GameEvents_onPlayerBulletCollidedWithBigMeteor()
    {
        AddScore(meteorBigDestroyingScore);
    }
    private void GameEvents_onPlayerBulletCollidedWithMediumMeteor()
    {
        AddScore(meteorMediumDestroyingScore);
    }

    private void GameEvents_onPlayerBulletCollidedWithUfo()
    {
        AddScore(ufoDestroyingScore);
    }

    private void GameEvents_onPlayerCollidedWithUfo()
    {
        AddScore(ufoDestroyingScore);
    }

    private void GameEvents_onPlayerCollidedWithBigMeteor()
    {
        RemoveHealth(meteorBigBumpHealthDecrease);
    }
    private void GameEvents_onPlayerCollidedWithMediumMeteor()
    {
        RemoveHealth(meteorMediumBumpHealthDecrease);
    }

    private void GameEvents_onPlayerCollidedWithUfoBullet()
    {
        RemoveHealth(ufoHitHealthDecrease);
    }

    private void RemoveHealth(int count)
    {
        healthValueSO.RemoveValue(count);
        if(healthValueSO.Value <= 0)
        {
            GameEvents.Instance.GameOver();
        }
    }

    private void AddScore(int count)
    {
        scoreValueSO.AddValue(count);
    }
}
