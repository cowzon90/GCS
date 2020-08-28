using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeachView.Ucs.Common
{
    public enum InputType
    {
        NONE = 0,
        ALT = 1,
    }

    public partial class FormInputText : Form
    {
        public FormInputText()
        {
            InitializeComponent();
        }

        public InputType InputType { get; private set; }

        public FormInputText(InputType type) : this()
        {
            this.InputType = type;
            this.InitUI_FormInputText();
        }

        /// <summary>
        /// Message.
        /// </summary>
        public string Message
        {
            get => this.LabelText.Text;
            private set => this.LabelText.Text = value;
        }

        /// <summary>
        /// Text to value.
        /// </summary>
        public object Value
        {
            get
            {
                string t = this.TextBoxInput.Text;
                if (t.Equals(string.Empty)) return null;

                try
                {
                    return Convert.ChangeType(t, this.ValueType);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public Type ValueType { get; private set; }

        private void InitUI_FormInputText_ALT()
        {
            this.Message = "Input target altitude (m)";
            this.ValueType = typeof(float);
        }

        private void InitUI_FormInputText()
        {
            switch (this.InputType)
            {
                case InputType.ALT:
                    this.InitUI_FormInputText_ALT();
                    break;
                default:
                    break;
            }
        }
    }
}
