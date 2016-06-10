using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace SFSReaderClass
{
    public class SFSReaderClass
    {
        // public variables that can be accessed from other calls
        public Int32 sfsLinesCount; // the lines count of the sfs file
        public string errorMessage; // variable to store and show any error message
        public TreeNode nodeList = new TreeNode("SFS File"); // the root node name of the list view item
        public string[,,,] sfsFileIndex; // 5-d array to store all values and index them based on original line no. and treeview index
        public DataSet SFSFile_Dataset = new DataSet("sfsFile_Dataset");
        public DataTable sfsFile_Table = new DataTable("sfsFile_Table");
        //
        // private class variables that can only be access from inside the class
        private Int32 _privateLineCount;

        // main method toread the files and work with it
        public bool openSFSFile(string fileName)
        {
            bool openFileStat=false;
            // preparing dataset
            prepareDataSet();
            try
            {
                // reading the file and storing it into an array
                string[] allLines = System.IO.File.ReadAllLines(fileName);
                // getting lines count
                sfsLinesCount = allLines.Count();
                _privateLineCount = allLines.Count();
                // building the nodes
                buildNodes(allLines, _privateLineCount);
                // setting the status to true, which means we did open the file successfully
                openFileStat = true;
                errorMessage = "";
            }
            catch (Exception ex)
            {
                // an error occurred!
                openFileStat = false;
                errorMessage = ex.ToString();
            }
            // returning the final result, whether it was good or bad
            return openFileStat;
        }

        // private method to read the file line by line and build the nodes and map them
        private void buildNodes(string[] lines, Int32 linesCount)
        {
            // reading the file line by line and load it into treeview nodes
            // regex to remove the tab spaces from brackets
            Regex removeTabs = new Regex("\\t+");
            // adding the sub nodes
            buildSubNodes(lines, linesCount, 0, nodeList);
        }

        private void buildSubNodes(string[] lines, Int32 linesCount, Int32 currentLine, TreeNode nodeObject)
        {
            //
            // if the value is } then we will check the level index, if it is 0, we will exit this method
            // if the level index is not 0, then we will reduce by 1 and keep adding sub-nodes
            // if the current value is a {, then we will make a new subnode and mark we have gone down 1 level
            //
            // getting current nodes count
            Int32 currentNode = currentLine; // index to know on which line/node we are in the file
            Int32 nodesCount = nodeObject.Nodes.Count; // the count of all nodes in the file
            Regex removeTabs = new Regex("\\t+"); // regex to match and remove tab characters
            Int32 nodeLevel = 0; // counter to set the indent of nodes
            List<TreeNode> nodeStructure = new List<TreeNode>(); // list to add nodes and sub nodes in
            string matchText=""; // the actual text of the node without the tab characters
            string checkNextNode; // a string variable to check the next node if it is a closing bracket
            //
            nodeStructure.Add(nodeObject); //adding the first node item to a list to work with it
            do
            {
                // removing tab characters and check the value of the node item
                matchText = removeTabs.Replace(lines[currentNode], "");
                // checking the value of the node if it is a bracket "{" or not
                switch (matchText)
                {
                    case "{":
                        // here we have the value as a bracket "{" so we will add the current node to the list
                        // so we can work with it and add sub nodes to it, then increament the node indent by 1
                        nodeLevel += 1;
                        nodeStructure.Add(nodeObject); //adding the first node item to a list to work with it
                        currentNode = currentNode + 1; //moving to the next line
                        break;
                    case "}":
                        // the value is a closing bracket "}", so we will not add anything here, and we will decrease
                        // now will check again if the node we will add is a closing bracket "}"
                        // the node indent by 1 and return to the parent node
                        nodeStructure.Remove(nodeStructure[nodeLevel]); //deleting the previous node
                        nodeLevel -= 1;
                        // regex to check if there are brackets after the first one we see
                        checkNextNode = removeTabs.Replace(lines[currentNode + 1], "");
                        switch (checkNextNode)
                        {
                            case "}":
                                // the next node is a closing bracket as well, so we need to skip 2 nodes
                                // before skipping, we need to delete the previous node as well so we get back to parent
                                nodeStructure.Remove(nodeStructure[nodeLevel]);
                                nodeLevel -= 1;
                                // moving to the next line
                                currentNode = currentNode + 2;
                                break;
                            default:
                                // here the next node is not a closing bracket
                                // as this node is a closing bracket "}", we need to skip to the next one
                                currentNode = currentNode + 1;
                                break;
                        }
                        break;
                    default:
                        // not a closing bracket
                        nodeObject = nodeStructure[nodeLevel].Nodes.Add(lines[currentNode]);
                        // nodeObject
                        // building the node index
                        // the index is the combination of the node's index with the full path of its parents index
                        //IList<TreeNode> ancestorList = TreeHelpers.GetAncestors(nodeObject, x => x.Parent).ToList();
                        makeSFSIndex(currentNode.ToString(), lines[currentNode], getNodePath(nodeObject));
                        // done building the node index
                        // nodeList.Nodes
                        currentNode = currentNode + 1;
                        break;
                }
            } while (currentNode < linesCount);
        }

        public string getNodePath(TreeNode nodeToGet)
        {
            string NodeIndex = null; // variable to store the node index in the treenode array
            IList<TreeNode> ancestorList = TreeHelpers.GetAncestors(nodeToGet, x => x.Parent).ToList();
            foreach (var item in ancestorList)
            {
                NodeIndex = NodeIndex + "." + item.Index.ToString();
            }
            return NodeIndex;
        }

        /// <summary>
        /// Making the index of the SFS file
        /// </summary>
        /// <param name="LineTxt"></param>
        /// <param name="nodeIndex"></param>
        private void makeSFSIndex(string lineNumber, string LineText, string nodePath)
        {
            // preparing the node index in the tree
            string[] propertyValue = null; // array to store the property and value of each line
            string propertyTitle = null; // var to store the property title
            string propertySetting = ""; //var to store the property settings
            //MessageBox.Show(nodeParentsPath.Count.ToString());
            // getting the actual line value to be splitted into 2 values:
            // tab + property name, value
            propertyValue = LineText.Split('=');
            propertyTitle = propertyValue[0];
            if (propertyValue.Length < 2)
            {
                propertySetting = "";
            }
            else
            {
                propertySetting = propertyValue[1];
            }
            // adding data into the array
            try
            {
                DataRow sfsFile_Row = sfsFile_Table.Rows.Add();
                sfsFile_Row.SetField("OriginalLineNo",lineNumber);
                sfsFile_Row.SetField("PropertName", propertyTitle);
                sfsFile_Row.SetField("PropertyValue", propertySetting);
                sfsFile_Row.SetField("NodeIndex", nodePath);
                //SFSFile_Dataset.Tables["sfsFile_Table"].Rows.Add(lineNumber, propertyValue[0], propertyValue[1], nodePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(lineNumber + " - " + propertyValue[0] + " " + propertyValue[1] + " " + nodePath);
            }
        }

        private void prepareDataSet()
        {
            try
            {
                // creating tables
                sfsFile_Table.Columns.Add("OriginalLineNo");
                sfsFile_Table.Columns.Add("PropertName");
                sfsFile_Table.Columns.Add("PropertyValue");
                sfsFile_Table.Columns.Add("NodeIndex");
                // filling the dataset
                SFSFile_Dataset.Tables.Add("sfsFile_Table");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

/**
 * dictionary
 * dataset
 * 5-dim array
 * 
 * 
 * 5-dim array:
 * line numebr index, tabs field, description, value, list view index
 * 
 * Not talking about the line number in the original file, it is easy
 * first, I got to know the tabs and separate them from the line
 * Then, I got the separate the property from its value
 * Then, we add its index from the treeview control
 * 
 * 
 * **/