using System.Xml.Linq;

namespace Treeviewtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void add_node(string name = "New Node")
        {
            TreeNode newNode = new TreeNode(name);
            TreeNode selNode = treeView1.SelectedNode;
            if (selNode != null)
            {
                selNode.Nodes.Add(newNode);
                treeView1.SelectedNode.Expand();
            }
            else
            {
                treeView1.Nodes.Add(newNode);
                treeView1.SelectedNode = newNode;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_node();
        }

        private void add_child_button_Click(object sender, EventArgs e)
        {

        }
    }
}