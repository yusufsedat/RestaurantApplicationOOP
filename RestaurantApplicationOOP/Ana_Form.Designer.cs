
namespace RestaurantApplicationOOP
{
    partial class Ana_Form
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.Siparis = new System.Windows.Forms.Button();
            this.Depo = new System.Windows.Forms.Button();
            this.Yemek = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Siparis
            // 
            this.Siparis.Location = new System.Drawing.Point(12, 12);
            this.Siparis.Name = "Siparis";
            this.Siparis.Size = new System.Drawing.Size(334, 109);
            this.Siparis.TabIndex = 0;
            this.Siparis.Text = "Sipariş";
            this.Siparis.UseVisualStyleBackColor = true;
            this.Siparis.Click += new System.EventHandler(this.Siparis_Click);
            // 
            // Depo
            // 
            this.Depo.Location = new System.Drawing.Point(12, 140);
            this.Depo.Name = "Depo";
            this.Depo.Size = new System.Drawing.Size(334, 109);
            this.Depo.TabIndex = 1;
            this.Depo.Text = "Depo";
            this.Depo.UseVisualStyleBackColor = true;
            this.Depo.Click += new System.EventHandler(this.Depo_Click);
            // 
            // Yemek
            // 
            this.Yemek.Location = new System.Drawing.Point(12, 267);
            this.Yemek.Name = "Yemek";
            this.Yemek.Size = new System.Drawing.Size(334, 109);
            this.Yemek.TabIndex = 2;
            this.Yemek.Text = "Yemek";
            this.Yemek.UseVisualStyleBackColor = true;
            this.Yemek.Click += new System.EventHandler(this.Yemek_Click);
            // 
            // Ana_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 388);
            this.Controls.Add(this.Yemek);
            this.Controls.Add(this.Depo);
            this.Controls.Add(this.Siparis);
            this.Name = "Ana_Form";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Ana_Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Siparis;
        private System.Windows.Forms.Button Depo;
        private System.Windows.Forms.Button Yemek;
    }
}

