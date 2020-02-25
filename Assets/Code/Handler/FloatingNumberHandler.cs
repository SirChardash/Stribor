using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Handler
{
  public class FloatingNumberHandler : MonoBehaviour
  {
    public Text text;
    public int numberChange;
    public new Camera camera;
    private const int TimeToLive = 45;
    private const int TransparencyTimeStart = 35;
    private static readonly Vector3 MoveIncrement = new Vector3(0, 0.5f, 0);
    private int _time;

    private void Start()
    {
      text.color = numberChange >= 0 ? Color.green : Color.red;
      text.text = (numberChange > 0 ? "+" : "") + numberChange;
      camera = Camera.main;
    }

    private void Update()
    {
      if (_time++ == TimeToLive)
      {
        Destroy(text);
        Destroy(this);
        return;
      }

      if (_time == TransparencyTimeStart) text.CrossFadeAlpha(0, (TimeToLive - TransparencyTimeStart) / 60f, false);
      text.transform.position = camera.ScreenToWorldPoint(camera.WorldToScreenPoint(text.transform.position) +
                                                          MoveIncrement *
                                                          (float) (1 - Math.Pow(_time / (float) TimeToLive, 2)));
    }
  }
}