using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stroymodern
{
    public partial class ListItem : UserControl
    {
        public ListItem()
        {
            InitializeComponent();
        }
        #region Properties
        private string _article;
        private string _name_product;
        private string _coust;
        private Image _icon;

        [Category("Custom Props")]
        public string Article
        {
            get { return _article; }
            set { _article = value; label_article.Text = value; }
        }

        [Category("Custom Props")]
        public string Name_product
        {
            get { return _name_product; }
            set { _name_product = value; label_name_product.Text = value; }
        }

        [Category("Custom Props")]
        public string Coust
        {
            get { return _coust; }
            set { _coust = value; label_coust_number.Text = value; }
        }

        [Category("Custom Props")]
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pictureBox_product.Image = value; }
        }
        #endregion
    }
}
