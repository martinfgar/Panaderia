using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionGrafica
{
    public partial class MostrarDiccionarioTabla<T,K> : Form
    {
        public MostrarDiccionarioTabla(String[] nombres,Dictionary<T,K> dict)
        {
            InitializeComponent();
            listView1.Columns.Add(nombres[0]);
            listView1.Columns.Add(nombres[1]);
            foreach (KeyValuePair<T, K> kvp in dict) {
                listView1.Items.Add(new ListViewItem(new String[] { kvp.Key.ToString(), kvp.Value.ToString() }));
            }
            
        }
    }
}
