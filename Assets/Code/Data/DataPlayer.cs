using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataPlayer : MonoBehaviour
{
    [SerializeField] private int _playerHp;
    [SerializeField] private Transform _label;
    [SerializeField] private Slider _prefabSliderHp;
    [SerializeField] private Slider _sliderPlayerHp;
    [SerializeField] private Canvas _myGui;
    [SerializeField] private Camera MyCamera;
    private int PlayerHp { get => _playerHp; set => _playerHp = value; }
    public Action<int> Damage;
    private IDamage Damagecalculate;
    private void Start()
    {
        Damagecalculate = new CalculationDamag();
        Damage += Updatehp;
         _sliderPlayerHp =  GameObject.Instantiate(_prefabSliderHp, _label.transform.position, Quaternion.identity);
        _sliderPlayerHp.transform.SetParent(_myGui.transform, true);
        _sliderPlayerHp.GetComponent<RectTransform>().localScale = new Vector3(0.3f, 0.25f, 0.1f);

    }
    private void Update()
    {
        Vector3 scrinPos = MyCamera.WorldToScreenPoint(_label.position);
        _sliderPlayerHp.transform.position = new Vector3(scrinPos.x, scrinPos.y, _sliderPlayerHp.transform.position.y);
        Debug.Log(scrinPos + " " + _label.position);
    }
    private void Updatehp(int Damage)
    {


        var RemsmingHp = Damagecalculate.CalculateCurrentDamage(Damage, PlayerHp);
        if (RemsmingHp == 0)
        {
            Debug.LogError("Плеер умер"); // Запускать анимацию зи pup master
        }
        else
        {
            PlayerHp = RemsmingHp;
            Debug.Log("Current Hp Player" + PlayerHp);
        }
    }

}
public class Damage 
{
    public int DamagToLaser = 1;
    public int Enemy;
}
public class CalculationDamag : IDamage
{
    public int CalculateCurrentDamage(int Damage, int CurrentHp)
    {
        if (Damage > CurrentHp)
        {
            return 0;
        }
        else
        {
            CurrentHp -= Damage;
            return CurrentHp;
        }
    }
}
public interface IDamage
{
    public int CalculateCurrentDamage(int Damage, int CurrentHp);
}