namespace GraphicalUIDemo
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.addBallBtn = new System.Windows.Forms.Button();
            this.addSpriteBtn = new System.Windows.Forms.Button();
            this.addRectangleBtn = new System.Windows.Forms.Button();
            this.addTriangleBtn = new System.Windows.Forms.Button();
            this.addStar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.Transparent;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(216, 106);
            this.canvas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(833, 454);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // addBallBtn
            // 
            this.addBallBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBallBtn.Location = new System.Drawing.Point(18, 106);
            this.addBallBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addBallBtn.Name = "addBallBtn";
            this.addBallBtn.Size = new System.Drawing.Size(162, 52);
            this.addBallBtn.TabIndex = 1;
            this.addBallBtn.Text = "Add Ball";
            this.addBallBtn.UseVisualStyleBackColor = true;
            this.addBallBtn.Click += new System.EventHandler(this.addBallBtn_Click);
            // 
            // addSpriteBtn
            // 
            this.addSpriteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSpriteBtn.Location = new System.Drawing.Point(18, 191);
            this.addSpriteBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addSpriteBtn.Name = "addSpriteBtn";
            this.addSpriteBtn.Size = new System.Drawing.Size(162, 52);
            this.addSpriteBtn.TabIndex = 2;
            this.addSpriteBtn.Text = "Add Sprite";
            this.addSpriteBtn.UseVisualStyleBackColor = true;
            this.addSpriteBtn.Click += new System.EventHandler(this.addSpriteBtn_Click);
            // 
            // addRectangleBtn
            // 
            this.addRectangleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addRectangleBtn.Location = new System.Drawing.Point(18, 276);
            this.addRectangleBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addRectangleBtn.Name = "addRectangleBtn";
            this.addRectangleBtn.Size = new System.Drawing.Size(162, 52);
            this.addRectangleBtn.TabIndex = 3;
            this.addRectangleBtn.Text = "Add Rectangle";
            this.addRectangleBtn.UseVisualStyleBackColor = true;
            this.addRectangleBtn.Click += new System.EventHandler(this.addRectangleBtn_Click);
            // 
            // addTriangleBtn
            // 
            this.addTriangleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTriangleBtn.Location = new System.Drawing.Point(18, 364);
            this.addTriangleBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addTriangleBtn.Name = "addTriangleBtn";
            this.addTriangleBtn.Size = new System.Drawing.Size(162, 52);
            this.addTriangleBtn.TabIndex = 4;
            this.addTriangleBtn.Text = "Add Triangle";
            this.addTriangleBtn.UseVisualStyleBackColor = true;
            this.addTriangleBtn.Click += new System.EventHandler(this.addTriangleBtn_Click);
            // 
            // addStar
            // 
            this.addStar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStar.Location = new System.Drawing.Point(18, 444);
            this.addStar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addStar.Name = "addStar";
            this.addStar.Size = new System.Drawing.Size(162, 52);
            this.addStar.TabIndex = 5;
            this.addStar.Text = "Add Star";
            this.addStar.UseVisualStyleBackColor = true;
            this.addStar.Click += new System.EventHandler(this.addStar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 692);
            this.Controls.Add(this.addStar);
            this.Controls.Add(this.addTriangleBtn);
            this.Controls.Add(this.addRectangleBtn);
            this.Controls.Add(this.addSpriteBtn);
            this.Controls.Add(this.addBallBtn);
            this.Controls.Add(this.canvas);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button addBallBtn;
        private System.Windows.Forms.Button addSpriteBtn;
        private System.Windows.Forms.Button addRectangleBtn;
        private System.Windows.Forms.Button addTriangleBtn;
        private System.Windows.Forms.Button addStar;
    }
}

