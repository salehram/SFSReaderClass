using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFSReaderClass_Sample.Forms
{
    public partial class frmMain : Form
    {
        // class-level definitions
        SFSReaderClass.SFSReaderClass readFile = new SFSReaderClass.SFSReaderClass();
        SFSReaderClass.TreeHelpers getNodeIndex;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnLoadSFSFile_Click(object sender, EventArgs e)
        {
            // defining new open file dialog object
            OpenFileDialog openFile = new OpenFileDialog();
            // setting the filters to only SFS extension
            openFile.Filter = "SFS save files (*.sfs)|*.sfs";
            openFile.FilterIndex = 0;
            openFile.Multiselect = false;
            // showing the dialog box
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // opening the file to read it
                    readFile.openSFSFile(openFile.FileName);
                    // printing the file name on the form for reference
                    lblSFSFileName.Text = openFile.FileName;
                    // returning the total line numebrs of the sfs file
                    lblNumberOfLines.Text = readFile.sfsLinesCount.ToString("N0");
                    // building the nodes
                    // -------code to build the nodes here
                    // displaying the number of nodes in the sfs file
                    // -------code to display nodes number here
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblNumberOfNodes.Text = readFile.nodeList.GetNodeCount(true).ToString();
            treeView1.Nodes.Add(readFile.nodeList);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode currentNode = treeView1.Nodes[treeView1.SelectedNode.Index];
            IList<TreeNode> nodeParent = getNodeIndex.GetAncestors(currentNode.Index, x => x.Parent).ToList();
        }
    }
}
