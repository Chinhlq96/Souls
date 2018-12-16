using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SA {
    public class UI_UpdateSliderFromVariable : GameEventListener {

        public Slider slider;
        public IntVariable targetInt;

        public override void Raise()
        {
            slider.value = targetInt.value;
            base.Raise();
        }
    }
}