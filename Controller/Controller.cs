using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Evolution;
using System.Reflection;

namespace ControllerForm
{
    public partial class Controller : Form
    {
        private byte[] hiddenLayers;
        private SemenGame game;
        public Controller()
        {
            InitializeComponent();
            game = new SemenGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            screenHeight.Value = SemenGame.ScreenHeight;
            screenWidth.Value = SemenGame.ScreenWidth;
            fps.Value = (decimal)SemenGame.Fps;
            stepSize.Value = Player.StepSize;
            rotationAngle.Value = Player.RotationAngle;
            initialLife.Value = Player.InitialLife;
            initialDirection.Value = Player.InitialDirection;
            foodLifeBonus.Value = Player.FoodLifeBonus;
            playerScale.Value = (decimal)Player.Scale;
            foodCount.Value = Evolution.Environment.foodCount;
            generationSize.Value = Manager.GenerationSize;
            bestfitsCount.Value = Manager.BestfitsCount;
            bestfitsCount.Maximum = generationSize.Value;
            hiddenLayers = Creature.HiddenLayers;
            newManager.Checked = false;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            GameParameters newParams = new GameParameters
            {
                Pause = pause.Checked,
                ScreenWidth = (int)screenWidth.Value,
                ScreenHeight = (int)screenHeight.Value,
                Fps = (float)fps.Value,
                StepSize = (int)stepSize.Value,
                RotationAngle = (int)rotationAngle.Value,
                InitialLife = (int)initialLife.Value,
                InitialDirection = (int)initialDirection.Value,
                FoodLifeBonus = (int)foodLifeBonus.Value,
                Scale = (float)playerScale.Value,
                FoodCount = (int)foodCount.Value,
                GenerationSize = (int)generationSize.Value,
                BestfitsCount = (int)bestfitsCount.Value,
                NewManager = newManager.Checked,
                HiddenLayers = hiddenLayers
            };
            game.NewGameParameters = newParams;
        }

        public void RunGame()
        {
            using (game = new SemenGame())
            {
                game.Run();
            }
        }

        private void generationSize_ValueChanged(object sender, EventArgs e)
        {
            bestfitsCount.Maximum = generationSize.Value;
            newManager.Checked = true;
        }
    }
}
