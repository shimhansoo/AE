using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform camera;
    public interface IPerception
    {
        void FindTarget(Transform target);
        void LostTarget(Transform target);
    }
    public interface ITotem
    {
        void SetDebuffTime(float time);
        void EndDebuff();
    }
    public interface IBattle
    {
        void OnTakeDamage(float dmg);
    }

    private void Awake()
    {
        Instance = this;
    }
}
