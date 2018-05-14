using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Rinner.Forms
{
    public partial class StringValuePage : UserControl
    {
        public StringValuePage()
        {
            InitializeComponent();
        }

        public string StringFormat
        {
            get { return cbxFormat.Text; }
            set { cbxFormat.Text = value; }
        }

        public string Value
        {
            get { return txtValue.Text.Trim(); }
            set { txtValue.Text = value; }
        }

        private void cbxFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            var format = cbxFormat.SelectedItem;
            
            switch (format)
            {
                case "Json":
                    string value = Value;
                    if (FormatJsonString(ref value))
                    {
                        Value = value;
                    }
                    break;
                case "Text":
                default:
                    break;
            }
        }

        private bool FormatJsonString(ref string str)
        {
            try
            {
                //格式化json字符串
                JsonSerializer serializer = new JsonSerializer();
                TextReader tr = new StringReader(str);
                JsonTextReader jtr = new JsonTextReader(tr);
                object obj = serializer.Deserialize(jtr);
                if (obj != null)
                {
                    StringWriter textWriter = new StringWriter();
                    JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                    {
                        Formatting = Formatting.Indented,
                        Indentation = 4,
                        IndentChar = ' '
                    };
                    serializer.Serialize(jsonWriter, obj);
                    str = textWriter.ToString();
                    return true;
                }
                else
                    return false;
            }
            catch 
            {
                return false;
            }
        }
    }
}
