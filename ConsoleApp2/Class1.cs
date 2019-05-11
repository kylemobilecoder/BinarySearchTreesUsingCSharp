//TreeNode Class
//Added a TreeNode class for the different functions and methods for every object/value/data passed by the user
using System;

namespace ConsoleApp2
{

    public class TreeNode
    {
        private int data;
        public int Data
        {
            get { return data; }
        }

        private TreeNode rightNode;
        public TreeNode RightNode
        {
            get { return rightNode; }
            set { rightNode = value; }
        }//Right Child

        private TreeNode leftNode;
        public TreeNode LeftNode
        {
            get { return leftNode; }
            set { leftNode = value; }
        }//left Child

        private bool isDeleted;//soft delete variable
        private TreeNode root;

        public bool IsDeleted
        {
            get { return isDeleted; }
        }

        public TreeNode Parent { get; private set; }

        //Node constructor
        public TreeNode(int value)
        {
            data = value;
        }

        //Method to set soft delete
        public void Delete()
        {
            isDeleted = true;
        }

        public TreeNode Find(int value)
        {

            TreeNode currentNode = this; //this node is the starting current node


            while (currentNode != null)   //loop through this node and all of the children of this node
            {
                //if the current nodes data is equal to the value passed in return it
                if (value == currentNode.data && isDeleted == false)//soft delete check
                {
                    Console.WriteLine("Value is in BST.");
                    return currentNode;          

                }
                else if (value > currentNode.data)//if the value passed in is greater than the current data then go to the right child
                {
                    currentNode = currentNode.rightNode;
                    //Console.WriteLine("Value is in BST");
                }
                else//otherwise if the value is less than the current nodes data the go to the left child node 
                {
                    currentNode = currentNode.leftNode;
                    //Console.WriteLine("Value is in BST");
                }
            }
            //Node is not found
            Console.WriteLine("Value is not found in BST.");
            return null;


        }

        public TreeNode FindRecursive(int value)
        {

            if (value == data && isDeleted == false) //value passed in matches nodes data return the node
            {
                return this;
            }
            else if (value < data && leftNode != null)//if the value passed in is less than the current data then go to the left child
            {
                return leftNode.FindRecursive(value);
            }
            else if (rightNode != null)//if its great then go to the right child node
            {
                return rightNode.FindRecursive(value);
            }
            else
            {
                return null;
            }
        }


        //recursively calls insert down the tree until it find an open spot
        public void Insert(int value)
        {
            //if the value passed in is greater or equal to the data then insert to right node
            if (value >= data)
            {   //if right child node is null create one
                if (rightNode == null)
                {
                    rightNode = new TreeNode(value);
                }
                else
                {//if right node is not null recursivly call insert on the right node
                    rightNode.Insert(value);
                }
            }
            else
            {//if the value passed in is less than the data then insert to left node
                if (leftNode == null)
                {//if the leftnode is null then create a new node
                    leftNode = new TreeNode(value);
                }
                else
                {//if the left node is not null then recursively call insert on the left node
                    leftNode.Insert(value);
                }
            }
        }

        public Nullable<int> SmallestValue()
        {
            // once we reach the last left node we return its data
            if (leftNode == null)
            {
                return data;
            }
            else
            {//otherwise keep calling the next left node
                return leftNode.SmallestValue();
            }
        }

        internal Nullable<int> LargestValue()
        {   // once we reach the last right node we return its data
            if (rightNode == null)
            {
                return data;
            }
            else
            {//otherwise keep calling the next right node
                return rightNode.LargestValue();
            }
        }

        //Values return in ascending order
        //Left->Root->Right Nodes recursively of each subtree 
        public void InOrderTraversal()
        {
            //first go to left child its children will be null so we print its data
            if (leftNode != null)
                leftNode.InOrderTraversal();
            //Then we print the root node 
            Console.Write(data + " ");

            //Then we go to the right node which will print itself as both its children are null
            if (rightNode != null)
                rightNode.InOrderTraversal();

        }
       
    }

}
     

