namespace powder_sandbox_game
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pctDisplay = new System.Windows.Forms.PictureBox();
            this.tmrTick = new System.Windows.Forms.Timer(this.components);
            this.btnSand = new System.Windows.Forms.Button();
            this.btnWater = new System.Windows.Forms.Button();
            this.trbBrushSize = new System.Windows.Forms.TrackBar();
            this.btnEraser = new System.Windows.Forms.Button();
            this.btnStone = new System.Windows.Forms.Button();
            this.btnBalls = new System.Windows.Forms.Button();
            this.btnWood = new System.Windows.Forms.Button();
            this.btnLava = new System.Windows.Forms.Button();
            this.btnFire = new System.Windows.Forms.Button();
            this.btnOil = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnPaused = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStep = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnSquare = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPaused = new System.Windows.Forms.Label();
            this.chbOverwrite = new System.Windows.Forms.CheckBox();
            this.btnGravel = new System.Windows.Forms.Button();
            this.btnExplode = new System.Windows.Forms.Button();
            this.btnObsidian = new System.Windows.Forms.Button();
            this.btnGunpowder = new System.Windows.Forms.Button();
            this.btnC4 = new System.Windows.Forms.Button();
            this.btnNitroglycerin = new System.Windows.Forms.Button();
            this.btnDust = new System.Windows.Forms.Button();
            this.btnSmoke = new System.Windows.Forms.Button();
            this.cmbTheme = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIce = new System.Windows.Forms.Button();
            this.btnSnow = new System.Windows.Forms.Button();
            this.trbSize = new System.Windows.Forms.TrackBar();
            this.lblSize = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbBrushSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSize)).BeginInit();
            this.SuspendLayout();
            // 
            // pctDisplay
            // 
            this.pctDisplay.Location = new System.Drawing.Point(13, 13);
            this.pctDisplay.Name = "pctDisplay";
            this.pctDisplay.Size = new System.Drawing.Size(775, 362);
            this.pctDisplay.TabIndex = 0;
            this.pctDisplay.TabStop = false;
            this.pctDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pctDisplay_MouseDown);
            this.pctDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctDisplay_MouseMove);
            this.pctDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pctDisplay_MouseUp);
            // 
            // tmrTick
            // 
            this.tmrTick.Enabled = true;
            this.tmrTick.Interval = 8;
            this.tmrTick.Tick += new System.EventHandler(this.tmrTick_Tick);
            // 
            // btnSand
            // 
            this.btnSand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSand.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSand.Location = new System.Drawing.Point(13, 389);
            this.btnSand.Name = "btnSand";
            this.btnSand.Size = new System.Drawing.Size(65, 25);
            this.btnSand.TabIndex = 2;
            this.btnSand.Text = "SAND";
            this.btnSand.UseVisualStyleBackColor = true;
            this.btnSand.Click += new System.EventHandler(this.btnSand_Click);
            // 
            // btnWater
            // 
            this.btnWater.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnWater.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWater.Location = new System.Drawing.Point(84, 389);
            this.btnWater.Name = "btnWater";
            this.btnWater.Size = new System.Drawing.Size(65, 25);
            this.btnWater.TabIndex = 3;
            this.btnWater.Text = "WATER";
            this.btnWater.UseVisualStyleBackColor = true;
            this.btnWater.Click += new System.EventHandler(this.btnWater_Click);
            // 
            // trbBrushSize
            // 
            this.trbBrushSize.Location = new System.Drawing.Point(642, 400);
            this.trbBrushSize.Maximum = 64;
            this.trbBrushSize.Minimum = 1;
            this.trbBrushSize.Name = "trbBrushSize";
            this.trbBrushSize.Size = new System.Drawing.Size(146, 45);
            this.trbBrushSize.SmallChange = 4;
            this.trbBrushSize.TabIndex = 4;
            this.trbBrushSize.TickFrequency = 2;
            this.trbBrushSize.Value = 8;
            // 
            // btnEraser
            // 
            this.btnEraser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEraser.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEraser.Location = new System.Drawing.Point(519, 398);
            this.btnEraser.Name = "btnEraser";
            this.btnEraser.Size = new System.Drawing.Size(117, 45);
            this.btnEraser.TabIndex = 5;
            this.btnEraser.Text = "ERASER";
            this.btnEraser.UseVisualStyleBackColor = true;
            this.btnEraser.Click += new System.EventHandler(this.btnEraser_Click);
            // 
            // btnStone
            // 
            this.btnStone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStone.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStone.Location = new System.Drawing.Point(155, 389);
            this.btnStone.Name = "btnStone";
            this.btnStone.Size = new System.Drawing.Size(72, 25);
            this.btnStone.TabIndex = 6;
            this.btnStone.Text = "STONE";
            this.btnStone.UseVisualStyleBackColor = true;
            this.btnStone.Click += new System.EventHandler(this.btnStone_Click);
            // 
            // btnBalls
            // 
            this.btnBalls.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBalls.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBalls.Location = new System.Drawing.Point(12, 451);
            this.btnBalls.Name = "btnBalls";
            this.btnBalls.Size = new System.Drawing.Size(66, 25);
            this.btnBalls.TabIndex = 7;
            this.btnBalls.Text = "BALLS";
            this.btnBalls.UseVisualStyleBackColor = true;
            this.btnBalls.Click += new System.EventHandler(this.btnBalls_Click);
            // 
            // btnWood
            // 
            this.btnWood.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnWood.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWood.Location = new System.Drawing.Point(155, 420);
            this.btnWood.Name = "btnWood";
            this.btnWood.Size = new System.Drawing.Size(72, 25);
            this.btnWood.TabIndex = 8;
            this.btnWood.Text = "WOOD";
            this.btnWood.UseVisualStyleBackColor = true;
            this.btnWood.Click += new System.EventHandler(this.btnWood_Click);
            // 
            // btnLava
            // 
            this.btnLava.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLava.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLava.Location = new System.Drawing.Point(84, 451);
            this.btnLava.Name = "btnLava";
            this.btnLava.Size = new System.Drawing.Size(65, 25);
            this.btnLava.TabIndex = 9;
            this.btnLava.Text = "LAVA";
            this.btnLava.UseVisualStyleBackColor = true;
            this.btnLava.Click += new System.EventHandler(this.btnLava_Click);
            // 
            // btnFire
            // 
            this.btnFire.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFire.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFire.Location = new System.Drawing.Point(233, 389);
            this.btnFire.Name = "btnFire";
            this.btnFire.Size = new System.Drawing.Size(78, 25);
            this.btnFire.TabIndex = 10;
            this.btnFire.Text = "FIRE";
            this.btnFire.UseVisualStyleBackColor = true;
            this.btnFire.Click += new System.EventHandler(this.btnFire_Click);
            // 
            // btnOil
            // 
            this.btnOil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOil.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOil.Location = new System.Drawing.Point(84, 420);
            this.btnOil.Name = "btnOil";
            this.btnOil.Size = new System.Drawing.Size(65, 25);
            this.btnOil.TabIndex = 11;
            this.btnOil.Text = "OIL";
            this.btnOil.UseVisualStyleBackColor = true;
            this.btnOil.Click += new System.EventHandler(this.btnOil_Click);
            // 
            // btnReset
            // 
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(794, 398);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(89, 45);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnPaused
            // 
            this.btnPaused.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPaused.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaused.Location = new System.Drawing.Point(794, 13);
            this.btnPaused.Name = "btnPaused";
            this.btnPaused.Size = new System.Drawing.Size(89, 45);
            this.btnPaused.TabIndex = 13;
            this.btnPaused.Text = "PAUSE";
            this.btnPaused.UseVisualStyleBackColor = true;
            this.btnPaused.Click += new System.EventHandler(this.btnPaused_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(649, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "BRUSH SIZE";
            // 
            // btnStep
            // 
            this.btnStep.Enabled = false;
            this.btnStep.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStep.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStep.Location = new System.Drawing.Point(794, 64);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(89, 45);
            this.btnStep.TabIndex = 15;
            this.btnStep.Text = "STEP";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCircle.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCircle.Location = new System.Drawing.Point(794, 281);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(86, 31);
            this.btnCircle.TabIndex = 16;
            this.btnCircle.Text = "Circle";
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btnSquare
            // 
            this.btnSquare.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSquare.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSquare.Location = new System.Drawing.Point(794, 318);
            this.btnSquare.Name = "btnSquare";
            this.btnSquare.Size = new System.Drawing.Size(86, 31);
            this.btnSquare.TabIndex = 17;
            this.btnSquare.Text = "Square";
            this.btnSquare.UseVisualStyleBackColor = true;
            this.btnSquare.Click += new System.EventHandler(this.btnSquare_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(792, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "BRUSH MODE";
            // 
            // lblPaused
            // 
            this.lblPaused.AutoSize = true;
            this.lblPaused.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaused.Location = new System.Drawing.Point(13, 0);
            this.lblPaused.Name = "lblPaused";
            this.lblPaused.Size = new System.Drawing.Size(43, 13);
            this.lblPaused.TabIndex = 19;
            this.lblPaused.Text = "Paused";
            this.lblPaused.Visible = false;
            // 
            // chbOverwrite
            // 
            this.chbOverwrite.AutoSize = true;
            this.chbOverwrite.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbOverwrite.Location = new System.Drawing.Point(795, 355);
            this.chbOverwrite.Name = "chbOverwrite";
            this.chbOverwrite.Size = new System.Drawing.Size(89, 19);
            this.chbOverwrite.TabIndex = 20;
            this.chbOverwrite.Text = "OVERWRITE";
            this.chbOverwrite.UseVisualStyleBackColor = true;
            // 
            // btnGravel
            // 
            this.btnGravel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGravel.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGravel.Location = new System.Drawing.Point(13, 420);
            this.btnGravel.Name = "btnGravel";
            this.btnGravel.Size = new System.Drawing.Size(65, 25);
            this.btnGravel.TabIndex = 21;
            this.btnGravel.Text = "GRAVEL";
            this.btnGravel.UseVisualStyleBackColor = true;
            this.btnGravel.Click += new System.EventHandler(this.btnGravel_Click);
            // 
            // btnExplode
            // 
            this.btnExplode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExplode.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExplode.Location = new System.Drawing.Point(233, 420);
            this.btnExplode.Name = "btnExplode";
            this.btnExplode.Size = new System.Drawing.Size(78, 25);
            this.btnExplode.TabIndex = 22;
            this.btnExplode.Text = "EXPLODE";
            this.btnExplode.UseVisualStyleBackColor = true;
            this.btnExplode.Click += new System.EventHandler(this.btnExplode_Click);
            // 
            // btnObsidian
            // 
            this.btnObsidian.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnObsidian.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObsidian.Location = new System.Drawing.Point(155, 451);
            this.btnObsidian.Name = "btnObsidian";
            this.btnObsidian.Size = new System.Drawing.Size(72, 25);
            this.btnObsidian.TabIndex = 23;
            this.btnObsidian.Text = "OBSIDIAN";
            this.btnObsidian.UseVisualStyleBackColor = true;
            this.btnObsidian.Click += new System.EventHandler(this.btnObsidian_Click);
            // 
            // btnGunpowder
            // 
            this.btnGunpowder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGunpowder.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGunpowder.Location = new System.Drawing.Point(233, 451);
            this.btnGunpowder.Name = "btnGunpowder";
            this.btnGunpowder.Size = new System.Drawing.Size(78, 25);
            this.btnGunpowder.TabIndex = 24;
            this.btnGunpowder.Text = "GUNPOWDER";
            this.btnGunpowder.UseVisualStyleBackColor = true;
            this.btnGunpowder.Click += new System.EventHandler(this.btnGunpowder_Click);
            // 
            // btnC4
            // 
            this.btnC4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnC4.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnC4.Location = new System.Drawing.Point(401, 389);
            this.btnC4.Name = "btnC4";
            this.btnC4.Size = new System.Drawing.Size(78, 25);
            this.btnC4.TabIndex = 25;
            this.btnC4.Text = "C4";
            this.btnC4.UseVisualStyleBackColor = true;
            this.btnC4.Click += new System.EventHandler(this.btnC4_Click);
            // 
            // btnNitroglycerin
            // 
            this.btnNitroglycerin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNitroglycerin.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNitroglycerin.Location = new System.Drawing.Point(401, 451);
            this.btnNitroglycerin.Name = "btnNitroglycerin";
            this.btnNitroglycerin.Size = new System.Drawing.Size(110, 25);
            this.btnNitroglycerin.TabIndex = 26;
            this.btnNitroglycerin.Text = "NITROGLYCERIN";
            this.btnNitroglycerin.UseVisualStyleBackColor = true;
            this.btnNitroglycerin.Click += new System.EventHandler(this.btnNitroglycerin_Click);
            // 
            // btnDust
            // 
            this.btnDust.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDust.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDust.Location = new System.Drawing.Point(317, 389);
            this.btnDust.Name = "btnDust";
            this.btnDust.Size = new System.Drawing.Size(78, 25);
            this.btnDust.TabIndex = 27;
            this.btnDust.Text = "DUST";
            this.btnDust.UseVisualStyleBackColor = true;
            this.btnDust.Click += new System.EventHandler(this.btnDust_Click);
            // 
            // btnSmoke
            // 
            this.btnSmoke.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSmoke.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSmoke.Location = new System.Drawing.Point(401, 418);
            this.btnSmoke.Name = "btnSmoke";
            this.btnSmoke.Size = new System.Drawing.Size(78, 25);
            this.btnSmoke.TabIndex = 28;
            this.btnSmoke.Text = "SMOKE";
            this.btnSmoke.UseVisualStyleBackColor = true;
            this.btnSmoke.Click += new System.EventHandler(this.btnSmoke_Click);
            // 
            // cmbTheme
            // 
            this.cmbTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTheme.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTheme.FormattingEnabled = true;
            this.cmbTheme.Items.AddRange(new object[] {
            "Light",
            "Dark",
            "Crazy"});
            this.cmbTheme.Location = new System.Drawing.Point(795, 147);
            this.cmbTheme.Name = "cmbTheme";
            this.cmbTheme.Size = new System.Drawing.Size(89, 26);
            this.cmbTheme.TabIndex = 29;
            this.cmbTheme.SelectedIndexChanged += new System.EventHandler(this.cmbTheme_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(793, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 18);
            this.label3.TabIndex = 30;
            this.label3.Text = "THEME";
            // 
            // btnIce
            // 
            this.btnIce.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIce.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIce.Location = new System.Drawing.Point(317, 420);
            this.btnIce.Name = "btnIce";
            this.btnIce.Size = new System.Drawing.Size(78, 25);
            this.btnIce.TabIndex = 31;
            this.btnIce.Text = "ICE";
            this.btnIce.UseVisualStyleBackColor = true;
            this.btnIce.Click += new System.EventHandler(this.btnIce_Click);
            // 
            // btnSnow
            // 
            this.btnSnow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSnow.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnow.Location = new System.Drawing.Point(317, 450);
            this.btnSnow.Name = "btnSnow";
            this.btnSnow.Size = new System.Drawing.Size(78, 25);
            this.btnSnow.TabIndex = 32;
            this.btnSnow.Text = "SNOW";
            this.btnSnow.UseVisualStyleBackColor = true;
            this.btnSnow.Click += new System.EventHandler(this.btnSnow_Click);
            // 
            // trbSize
            // 
            this.trbSize.LargeChange = 2;
            this.trbSize.Location = new System.Drawing.Point(791, 193);
            this.trbSize.Maximum = 5;
            this.trbSize.Minimum = 1;
            this.trbSize.Name = "trbSize";
            this.trbSize.Size = new System.Drawing.Size(89, 45);
            this.trbSize.TabIndex = 33;
            this.trbSize.Value = 4;
            this.trbSize.ValueChanged += new System.EventHandler(this.trbSize_ValueChanged);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(794, 179);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(40, 18);
            this.lblSize.TabIndex = 34;
            this.lblSize.Text = "SIZE";
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnApply.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(802, 224);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(71, 29);
            this.btnApply.TabIndex = 35;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(892, 488);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.trbSize);
            this.Controls.Add(this.btnSnow);
            this.Controls.Add(this.btnIce);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTheme);
            this.Controls.Add(this.btnSmoke);
            this.Controls.Add(this.btnDust);
            this.Controls.Add(this.btnNitroglycerin);
            this.Controls.Add(this.btnC4);
            this.Controls.Add(this.btnGunpowder);
            this.Controls.Add(this.btnObsidian);
            this.Controls.Add(this.btnExplode);
            this.Controls.Add(this.btnGravel);
            this.Controls.Add(this.chbOverwrite);
            this.Controls.Add(this.lblPaused);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSquare);
            this.Controls.Add(this.btnCircle);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPaused);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnOil);
            this.Controls.Add(this.btnFire);
            this.Controls.Add(this.btnLava);
            this.Controls.Add(this.btnWood);
            this.Controls.Add(this.btnBalls);
            this.Controls.Add(this.btnStone);
            this.Controls.Add(this.btnEraser);
            this.Controls.Add(this.trbBrushSize);
            this.Controls.Add(this.btnWater);
            this.Controls.Add(this.btnSand);
            this.Controls.Add(this.pctDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Powder Sandbox";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbBrushSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctDisplay;
        private System.Windows.Forms.Timer tmrTick;
        private System.Windows.Forms.Button btnSand;
        private System.Windows.Forms.Button btnWater;
        private System.Windows.Forms.TrackBar trbBrushSize;
        private System.Windows.Forms.Button btnEraser;
        private System.Windows.Forms.Button btnStone;
        private System.Windows.Forms.Button btnBalls;
        private System.Windows.Forms.Button btnWood;
        private System.Windows.Forms.Button btnLava;
        private System.Windows.Forms.Button btnFire;
        private System.Windows.Forms.Button btnOil;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnPaused;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btnSquare;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPaused;
        private System.Windows.Forms.CheckBox chbOverwrite;
        private System.Windows.Forms.Button btnGravel;
        private System.Windows.Forms.Button btnExplode;
        private System.Windows.Forms.Button btnObsidian;
        private System.Windows.Forms.Button btnGunpowder;
        private System.Windows.Forms.Button btnC4;
        private System.Windows.Forms.Button btnNitroglycerin;
        private System.Windows.Forms.Button btnDust;
        private System.Windows.Forms.Button btnSmoke;
        private System.Windows.Forms.ComboBox cmbTheme;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIce;
        private System.Windows.Forms.Button btnSnow;
        private System.Windows.Forms.TrackBar trbSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Button btnApply;
    }
}

