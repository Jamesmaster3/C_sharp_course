using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace test {
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form {
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Form1( ) {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing ) {
            if( disposing ) {
                if( components != null ) {
                    components.Dispose( );
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( ) {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(528, 248);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "This is some text.\nIt contains 12 words, not counting 15 delimiters!!!";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "DelimCount1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(93, 265);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Word Count";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(528, 297);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main( ) {
            Application.Run( new Form1( ) );
        }

        char[] DELIMS = new char[10] { ' ', '.', ',', '?', '!', '-', '_', '+', '*', '/' };
        int charcount = 0;

        private bool IsDelimiter( char c ) {
            bool delimfound = false;
            foreach( char mychar in DELIMS ) {
                if( mychar == c )
                    delimfound = true;
            }
            return delimfound;
        }

        private void FindDelims( ) {
            string s = richTextBox1.Text;
            int delimcount = 0;
            for( int i = 0; i < s.Length; i++ ) {
                if( IsDelimiter( s[i] ) )
                    delimcount++;
            }
            MessageBox.Show( "delimcount=" + delimcount,
                "Statistics",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information );
        }

        private bool ScrollThroughWord( string s ) {
            bool wordfound = false;
            while( ( charcount < s.Length ) && !( IsDelimiter( s[charcount] ) ) ) {
                charcount++;
                wordfound = true;
            }
            return wordfound;	 
        }

        private void ScrollThroughDelims( string s ) {
            while( ( charcount < s.Length ) && IsDelimiter( s[charcount] ) ) {
                charcount++;
            }
        }

        private void CountWordsAndCharacters( ) {
            string s = richTextBox1.Text;
            charcount = 0;
            int wordcount = 0;
            while( charcount < s.Length ) {
                ScrollThroughDelims( s );
                if( ScrollThroughWord( s ) ) {
                    wordcount++;
                }
            }
            this.Text = "Number of words: " + wordcount + " Characters: " + charcount;
        }

        private void button1_Click( object sender, System.EventArgs e ) {
            FindDelims( );
        }

 
        private void button3_Click( object sender, EventArgs e ) {
            CountWordsAndCharacters( );
        }

    }
}

