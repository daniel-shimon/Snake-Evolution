using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution
{
    public class GameParameters
    {
        public bool HasChanged = true;
        public bool Pause = false;
        // Xna:
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }
        public float Fps { get; set; }
        // Player:
        public int StepSize { get; set; }
        public int RotationAngle { get; set; }
        public int InitialLife { get; set; }
        public int InitialDirection { get; set; }
        public int FoodLifeBonus { get; set; }
        public float Scale { get; set; }
        // Environment:
        public int FoodCount { get; set; }
        // Evolution Manager:
        public int GenerationSize { get; set; }
        public int BestfitsCount { get; set; }
        public bool NewManager { get; set; }
        public byte[] HiddenLayers { get; set; }
    }
}