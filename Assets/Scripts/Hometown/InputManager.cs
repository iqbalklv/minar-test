using System;
using UnityEngine;

namespace Project.Hometown
{
    public class InputManager : MonoBehaviour
    {
        public event Action OnInputTouch;

        public void ClickUpgrade()
        {
            OnInputTouch?.Invoke();
        }
    }
}