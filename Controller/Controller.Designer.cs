namespace ControllerForm
{
    partial class Controller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.screenWidth = new System.Windows.Forms.NumericUpDown();
            this.screenHeight = new System.Windows.Forms.NumericUpDown();
            this.applyButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.stepSize = new System.Windows.Forms.NumericUpDown();
            this.rotationAngle = new System.Windows.Forms.NumericUpDown();
            this.initialLife = new System.Windows.Forms.NumericUpDown();
            this.initialDirection = new System.Windows.Forms.NumericUpDown();
            this.foodLifeBonus = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.playerScale = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.foodCount = new System.Windows.Forms.NumericUpDown();
            this.pause = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.generationSize = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.bestfitsCount = new System.Windows.Forms.NumericUpDown();
            this.newManager = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.hiddenLayerCount = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.layerNumber = new System.Windows.Forms.NumericUpDown();
            this.layerSize = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.fps = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.mutationRate = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.screenWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotationAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.initialLife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.initialDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foodLifeBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foodCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.generationSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bestfitsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiddenLayerCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationRate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Screen Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Screen Height";
            // 
            // screenWidth
            // 
            this.screenWidth.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.screenWidth.Location = new System.Drawing.Point(99, 29);
            this.screenWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.screenWidth.Name = "screenWidth";
            this.screenWidth.Size = new System.Drawing.Size(58, 20);
            this.screenWidth.TabIndex = 2;
            // 
            // screenHeight
            // 
            this.screenHeight.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.screenHeight.Location = new System.Drawing.Point(244, 29);
            this.screenHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.screenHeight.Name = "screenHeight";
            this.screenHeight.Size = new System.Drawing.Size(58, 20);
            this.screenHeight.TabIndex = 2;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(345, 366);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 3;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Xna :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Player :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Initial life";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(281, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Food life bonus";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(146, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Initial direction";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Step size";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(146, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Rotation Angle";
            // 
            // stepSize
            // 
            this.stepSize.Location = new System.Drawing.Point(74, 76);
            this.stepSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.stepSize.Name = "stepSize";
            this.stepSize.Size = new System.Drawing.Size(65, 20);
            this.stepSize.TabIndex = 11;
            // 
            // rotationAngle
            // 
            this.rotationAngle.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.rotationAngle.Location = new System.Drawing.Point(226, 76);
            this.rotationAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.rotationAngle.Name = "rotationAngle";
            this.rotationAngle.Size = new System.Drawing.Size(49, 20);
            this.rotationAngle.TabIndex = 12;
            // 
            // initialLife
            // 
            this.initialLife.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.initialLife.Location = new System.Drawing.Point(74, 110);
            this.initialLife.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.initialLife.Name = "initialLife";
            this.initialLife.Size = new System.Drawing.Size(65, 20);
            this.initialLife.TabIndex = 13;
            // 
            // initialDirection
            // 
            this.initialDirection.Location = new System.Drawing.Point(226, 110);
            this.initialDirection.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.initialDirection.Name = "initialDirection";
            this.initialDirection.Size = new System.Drawing.Size(49, 20);
            this.initialDirection.TabIndex = 13;
            // 
            // foodLifeBonus
            // 
            this.foodLifeBonus.Location = new System.Drawing.Point(366, 110);
            this.foodLifeBonus.Name = "foodLifeBonus";
            this.foodLifeBonus.Size = new System.Drawing.Size(54, 20);
            this.foodLifeBonus.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(281, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Scale";
            // 
            // playerScale
            // 
            this.playerScale.DecimalPlaces = 2;
            this.playerScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.playerScale.Location = new System.Drawing.Point(366, 76);
            this.playerScale.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.playerScale.Name = "playerScale";
            this.playerScale.Size = new System.Drawing.Size(54, 20);
            this.playerScale.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Environment:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Food Count";
            // 
            // foodCount
            // 
            this.foodCount.Location = new System.Drawing.Point(99, 162);
            this.foodCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.foodCount.Name = "foodCount";
            this.foodCount.Size = new System.Drawing.Size(71, 20);
            this.foodCount.TabIndex = 2;
            // 
            // pause
            // 
            this.pause.AutoSize = true;
            this.pause.Location = new System.Drawing.Point(281, 370);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(56, 17);
            this.pause.TabIndex = 15;
            this.pause.Text = "Pause";
            this.pause.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 191);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Evolution Manager:";
            // 
            // generationSize
            // 
            this.generationSize.Location = new System.Drawing.Point(110, 214);
            this.generationSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.generationSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.generationSize.Name = "generationSize";
            this.generationSize.Size = new System.Drawing.Size(71, 20);
            this.generationSize.TabIndex = 2;
            this.generationSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.generationSize.ValueChanged += new System.EventHandler(this.generationSize_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 216);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Genration Size";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(187, 216);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Bestfits Count";
            // 
            // bestfitsCount
            // 
            this.bestfitsCount.Location = new System.Drawing.Point(262, 214);
            this.bestfitsCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.bestfitsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bestfitsCount.Name = "bestfitsCount";
            this.bestfitsCount.Size = new System.Drawing.Size(40, 20);
            this.bestfitsCount.TabIndex = 2;
            this.bestfitsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // newManager
            // 
            this.newManager.AutoSize = true;
            this.newManager.Location = new System.Drawing.Point(132, 370);
            this.newManager.Name = "newManager";
            this.newManager.Size = new System.Drawing.Size(140, 17);
            this.newManager.TabIndex = 15;
            this.newManager.Text = "New Evolution Manager";
            this.newManager.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 248);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 13);
            this.label16.TabIndex = 5;
            this.label16.Text = "Neural Nets:";
            // 
            // hiddenLayerCount
            // 
            this.hiddenLayerCount.Location = new System.Drawing.Point(110, 270);
            this.hiddenLayerCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.hiddenLayerCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hiddenLayerCount.Name = "hiddenLayerCount";
            this.hiddenLayerCount.Size = new System.Drawing.Size(71, 20);
            this.hiddenLayerCount.TabIndex = 2;
            this.hiddenLayerCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hiddenLayerCount.ValueChanged += new System.EventHandler(this.generationSize_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(21, 272);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 13);
            this.label17.TabIndex = 6;
            this.label17.Text = "Hidden Layers";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(200, 272);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 13);
            this.label18.TabIndex = 6;
            this.label18.Text = "Layer No. ";
            // 
            // layerNumber
            // 
            this.layerNumber.Location = new System.Drawing.Point(262, 270);
            this.layerNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.layerNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.layerNumber.Name = "layerNumber";
            this.layerNumber.Size = new System.Drawing.Size(29, 20);
            this.layerNumber.TabIndex = 2;
            this.layerNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // layerSize
            // 
            this.layerSize.Location = new System.Drawing.Point(366, 270);
            this.layerSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.layerSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.layerSize.Name = "layerSize";
            this.layerSize.Size = new System.Drawing.Size(29, 20);
            this.layerSize.TabIndex = 2;
            this.layerSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(304, 272);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(59, 13);
            this.label19.TabIndex = 6;
            this.label19.Text = "Layer Size ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(310, 31);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(27, 13);
            this.label20.TabIndex = 1;
            this.label20.Text = "FPS";
            // 
            // fps
            // 
            this.fps.DecimalPlaces = 1;
            this.fps.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.fps.Location = new System.Drawing.Point(356, 29);
            this.fps.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.fps.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.fps.Name = "fps";
            this.fps.Size = new System.Drawing.Size(64, 20);
            this.fps.TabIndex = 2;
            this.fps.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(308, 216);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(74, 13);
            this.label21.TabIndex = 1;
            this.label21.Text = "Mutation Rate";
            // 
            // mutationRate
            // 
            this.mutationRate.Location = new System.Drawing.Point(388, 214);
            this.mutationRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.mutationRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mutationRate.Name = "mutationRate";
            this.mutationRate.Size = new System.Drawing.Size(40, 20);
            this.mutationRate.TabIndex = 2;
            this.mutationRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 401);
            this.Controls.Add(this.newManager);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.playerScale);
            this.Controls.Add(this.foodLifeBonus);
            this.Controls.Add(this.initialDirection);
            this.Controls.Add(this.initialLife);
            this.Controls.Add(this.rotationAngle);
            this.Controls.Add(this.stepSize);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.hiddenLayerCount);
            this.Controls.Add(this.layerSize);
            this.Controls.Add(this.generationSize);
            this.Controls.Add(this.layerNumber);
            this.Controls.Add(this.mutationRate);
            this.Controls.Add(this.bestfitsCount);
            this.Controls.Add(this.fps);
            this.Controls.Add(this.screenHeight);
            this.Controls.Add(this.foodCount);
            this.Controls.Add(this.screenWidth);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Controller";
            this.Text = "Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.screenWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotationAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.initialLife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.initialDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foodLifeBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foodCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.generationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bestfitsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiddenLayerCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown screenWidth;
        private System.Windows.Forms.NumericUpDown screenHeight;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown stepSize;
        private System.Windows.Forms.NumericUpDown rotationAngle;
        private System.Windows.Forms.NumericUpDown initialLife;
        private System.Windows.Forms.NumericUpDown initialDirection;
        private System.Windows.Forms.NumericUpDown foodLifeBonus;
        private System.Windows.Forms.NumericUpDown playerScale;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown foodCount;
        private System.Windows.Forms.CheckBox pause;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown generationSize;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown bestfitsCount;
        private System.Windows.Forms.CheckBox newManager;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown hiddenLayerCount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown layerNumber;
        private System.Windows.Forms.NumericUpDown layerSize;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown fps;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown mutationRate;
    }
}

