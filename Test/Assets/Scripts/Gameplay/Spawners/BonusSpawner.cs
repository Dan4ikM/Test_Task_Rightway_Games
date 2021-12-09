using UnityEngine;
using System.Collections;
using Gameplay.Bonus;

/// <summary>
/// Класс который будет спавнить бонусы на позициях умерших врагов
/// </summary>
public class BonusSpawner : MonoBehaviour
{
    [SerializeField]
    private Bonus[] bonusPrefabs;
    /// <summary>
    /// Метод который спавнит случайный бонус
    /// Так же можно добавить тут пулл объектов и ссылку на родителя Transform
    /// </summary>
    /// <param name="transform">Значения позиции и поворота, где появится бонус</param>
    public void SpawnRandomBonus(Transform transform)
    {
        int index = Random.Range(0, bonusPrefabs.Length);
        Instantiate(bonusPrefabs[index], transform.position, transform.rotation);
    }
}
